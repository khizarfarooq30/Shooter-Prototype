using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkConnectionManager : MonoBehaviourPunCallbacks
{
   [SerializeField] private string sceneName = "MatchMaking";
   
   private void Start()
   {
      Connect();
   }

   public void Connect()
   {
      PhotonNetwork.ConnectUsingSettings();
   }

   public override void OnConnectedToMaster()
   {
      base.OnConnectedToMaster();
      SceneManager.LoadScene(sceneName);
   }
}
