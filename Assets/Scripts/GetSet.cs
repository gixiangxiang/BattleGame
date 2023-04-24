using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSet : MonoBehaviour
{
  int i=10;//參與I的計算，不可調用
  public int I//僅為i的屬性，不會顯示在inspector面板，可以調用
  {
    get { return i; }//讀取i的值
    set
    {
      if (value > 10)
      {
        i = 10;
      }
      else
      {
        i = value;
      }
    }
  }

  void Start()
  {
    I+=10;
    Debug.Log(I);
  }
}
class Car
{
  public string Model { get; set; }
  public Car(string model)
  {
    this.Model = model;
  }
}


