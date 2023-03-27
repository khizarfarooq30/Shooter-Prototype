using Photon.Pun;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damageAmount = 4;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
           health.photonView.RPC("TakeDamage", RpcTarget.All, damageAmount);
        }
        
        PhotonNetwork.Destroy(gameObject);
    }
}
