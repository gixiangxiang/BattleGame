using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieController : MonoBehaviour
{
  public Image[] pieImages;
  public float[] values;

  public void SetValue(float[] valuesToSet)
  {
    float totalValues = 0;
    for (int i = 0; i < pieImages.Length; i++)
    {
      totalValues += 0;
    }
  }

  float FindPercentage(float[] valuesToSet, int index)
  {
    float totalAmount = 0;
    for (int i = 0; i < valuesToSet.Length; i++)
    {
      totalAmount += valuesToSet[i];
    }
    return totalAmount;
  }
}
