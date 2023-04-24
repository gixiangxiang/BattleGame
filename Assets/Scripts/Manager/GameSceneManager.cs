using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameSceneManager : MonoBehaviourPunCallbacks
{
  public static GameSceneManager instance;
  public Transform[] spawnPoints;
  int playerNum;
  void Start()
  {
    instance = this;

    foreach (Player p in PhotonNetwork.PlayerList)
    {
      if(p == PhotonNetwork.LocalPlayer)
      {
        PhotonNetwork.Instantiate("VirtualGuy",spawnPoints[playerNum].position,Quaternion.identity);
      }
      else
      {
        playerNum++;
      }
    }
  }


}
