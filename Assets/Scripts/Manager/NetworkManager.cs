using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
  public static NetworkManager network;
  [Header("檢查是否為Master")]
  public bool isMaster;

  void Awake()
  {
    network = this;
  }
  void Update()
  {
    isMaster = PhotonNetwork.IsMasterClient;
  }
  [Header("房間名")]
  public string roomName;

  public void OnClickConnect(string playerName)//連線至伺服器--由外部呼叫此方法
  {
    PhotonNetwork.LocalPlayer.NickName = playerName;//玩家名字
    PhotonNetwork.AutomaticallySyncScene = true;//同步轉場
    PhotonNetwork.ConnectUsingSettings();//連線至伺服器
  }

  public override void OnConnectedToMaster()//連上伺服器之後
  {
    PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);//隨機加入或創造房間
  }

  public override void OnJoinedRoom()
  {
    GameManager.GM.LoadScene(1);//加載房間場景
  }

  public string UpdatePlayerList()
  {
    StringBuilder sb = new StringBuilder();
    foreach (var kvp in PhotonNetwork.CurrentRoom.Players)
    {
      sb.AppendLine("→" + kvp.Value.NickName);
    }
    return sb.ToString();
  }


}
