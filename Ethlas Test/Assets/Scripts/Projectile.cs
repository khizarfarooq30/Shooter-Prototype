using Photon.Pun;
using UnityEngine;

public class Projectile : MonoBehaviourPun
{
    [SerializeField] private int damageAmount = 4;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
           health.photonView.RPC("TakeDamage", RpcTarget.All, damageAmount);
        }
        
        photonView.RPC("DestroyProjectileRPC", RpcTarget.All);
    }
    
    [PunRPC]
    private void DestroyProjectileRPC()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
