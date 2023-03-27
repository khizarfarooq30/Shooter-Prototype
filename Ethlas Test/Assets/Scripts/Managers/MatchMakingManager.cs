using System;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchMakingManager : MonoBehaviourPunCallbacks
{
   [SerializeField] private TMP_InputField createRoomInputField;
   [SerializeField] private TMP_InputField joinRoomInputField;

   [SerializeField] private string gameSceneName = "Game";
   
   private string playerName = "Player";
   private string roomName = "Room";

   private static int playerIndex;

   public void CreateRoom()
   {
      roomName = createRoomInputField.text;
      
      RoomOptions options = new RoomOptions
      {
         MaxPlayers = 2
      };

      playerIndex = 0;
      PhotonNetwork.CreateRoom(roomName, options);
   }

   public override void OnCreatedRoom()
   {
      playerIndex++;
      PhotonNetwork.LocalPlayer.NickName = playerName + " " + playerIndex;
   }

   public void JoinRoom()
   {
      PhotonNetwork.JoinRoom(joinRoomInputField.text);
   }
   
   public override void OnJoinedRoom()
   {
      Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name + " by" + PhotonNetwork.LocalPlayer.NickName);
      PhotonNetwork.LoadLevel(gameSceneName);
   }
}
