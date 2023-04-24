using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable
{
  PhotonView _pv;
  // GameObject myPlayer;
  // Player[] allPlayers;
  // int myNumberInRoom;

  public Text playerName;
  public Slider healthSlider;
  float health;

  public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
  {
    if (stream.IsWriting)
    {
      // 為玩家本人的狀態, 將 IsFiring 的狀態更新給其他玩家
      stream.SendNext(health);
    }
    else
    {
      // 非為玩家本人的狀態, 單純接收更新的資料
      this.health = (float)stream.ReceiveNext();
    }
  }

  void Start()
  {
    _pv = GetComponent<PhotonView>();
    playerName.text = _pv.Owner.NickName;
    health = healthSlider.maxValue;
  }

  void Update()
  {
    if (_pv.IsMine && Input.GetKeyDown(KeyCode.P))
    {
      health--;
    }
    healthSlider.value = health;
  }

}
