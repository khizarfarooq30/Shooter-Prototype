using Photon.Pun;
using UnityEngine;

public class PlayerShooter : MonoBehaviourPun
{
   [SerializeField] private Rigidbody projectileRb;
   [SerializeField] private Transform shootPoint;

   [SerializeField] private ParticleSystem muzzleFlash;
   
   public void ProcessShoot()
   {
      ShootProjectile();
   }

   private void ShootProjectile()
   {
      photonView.RPC("ShowMuzzleFlashEffect", RpcTarget.All);
      Rigidbody rb = PhotonNetwork.Instantiate(projectileRb.name, shootPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
      rb.AddForce(shootPoint.forward * 15f, ForceMode.Impulse);
   }

   [PunRPC]
   void ShowMuzzleFlashEffect()
   {
      muzzleFlash.Play();
   }
   
}
