using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSceneManager : MonoBehaviour
{
  public Text playerListTxt;
  public Button startGameBtn;
  void Start()
  {
    startGameBtn.onClick.AddListener(delegate ()
    {
      GameManager.GM.LoadScene(2);
    });
  }
  void Update()
  {
    playerListTxt.text = NetworkManager.network.UpdatePlayerList();
    startGameBtn.interactable = NetworkManager.network.isMaster;
  }

}
