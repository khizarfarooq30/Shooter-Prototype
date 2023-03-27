using Photon.Pun;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
   [SerializeField] private Rigidbody projectileRb;
   [SerializeField] private Transform shootPoint;
   
   public void ProcessShoot()
   {
      ShootProjectile();
   }

   private void ShootProjectile()
   {
      Rigidbody rb = PhotonNetwork.Instantiate(projectileRb.name, shootPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
      rb.AddForce(shootPoint.forward * 15f, ForceMode.Impulse);
   }
   
}
