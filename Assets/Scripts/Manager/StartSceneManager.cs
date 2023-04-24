using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{

  public string Model;
  public StartSceneManager(string model) { this.Model = model; }

  [SerializeField] InputField playerNameIpt;
  string GetPlayerName()
  {
    string playerName = playerNameIpt.text;//從InputField獲取玩家名字
    return playerName.Trim();
  }

  public void OnClickJoinRoom()//掛在按鈕上啟用
  {
    string playerName = GetPlayerName();
    if (playerName.Length > 0)
    {
      NetworkManager.network.OnClickConnect(playerName);
    }
    else
    {
      Debug.Log("Name Error");
    }
  }

}

