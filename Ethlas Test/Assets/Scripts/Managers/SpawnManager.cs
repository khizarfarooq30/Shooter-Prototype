using Cinemachine;
using Photon.Pun;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Transform[] spawnPoints;

    
    private static int previousPlayerIndex;
    
    private void Start()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        if (randomIndex == previousPlayerIndex)
        {
            randomIndex = Random.Range(previousPlayerIndex, spawnPoints.Length);
        }
        
        GameObject newPlayer = PhotonNetwork.Instantiate(playerObject.name, spawnPoints[randomIndex].position, Quaternion.identity);
        cinemachineVirtualCamera.Follow = newPlayer.transform;
        cinemachineVirtualCamera.LookAt = newPlayer.transform;
        
        previousPlayerIndex = randomIndex;
    }
}
