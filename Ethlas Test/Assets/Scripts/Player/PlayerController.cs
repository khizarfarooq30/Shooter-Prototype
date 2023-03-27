using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float shootTimerMax = 0.5f;
    private float shootTimer;
    
    private PlayerMovement playerMovement;
    private PlayerShooter playerShooter;
    private Health health;

    private PhotonView photonView;
    
    private void Start()
    {
        shootTimer = shootTimerMax;

        health = GetComponent<Health>();
        photonView = GetComponent<PhotonView>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooter = GetComponent<PlayerShooter>();
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            playerMovement.ProcessMove();
            
            shootTimer -= Time.deltaTime;
            
            if (shootTimer <= 0f && Input.GetMouseButtonDown(0))
            {
                shootTimer = shootTimerMax;
                playerShooter.ProcessShoot();
            }
  
        }
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            playerMovement.Move();
        }
    }
}