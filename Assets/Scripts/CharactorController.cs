using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharactorController : MonoBehaviourPunCallbacks
{
  PhotonView _pv;
  Rigidbody2D rb;
  [SerializeField] float speed;
  [SerializeField] int jumpPower;
  [SerializeField] LayerMask ground;
  [SerializeField] Transform feetCheck;

  void Start()
  {
    _pv = GetComponent<PhotonView>();
    rb = GetComponent<Rigidbody2D>();
  }
  void Update()
  {
    if (_pv.IsMine)
    {
      Movement();
      Jump();
    }

  }

  void Movement()
  {
    if (Input.GetButton("Horizontal"))
    {
      float hAxis = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(hAxis * speed, rb.velocity.y);
    }
  }

  void Jump()
  {
    if (Input.GetButtonDown("Jump") && isGround())
    {
      rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
    }
  }
  bool isGround()
  {
    return Physics2D.OverlapCapsule(feetCheck.position, new Vector2(0.5f, 0.09f), CapsuleDirection2D.Horizontal, 0, ground);
  }


}
