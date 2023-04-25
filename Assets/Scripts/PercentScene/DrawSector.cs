using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSector : MonoBehaviour
{
  public int segments = 50;
  public float radius = 1f;
  public float startAngle = 30f;
  public float endAngle = 120f;

  private LineRenderer line;

  void Start()
  {
    line = gameObject.GetComponent<LineRenderer>();

    line.positionCount = segments + 1;
    line.useWorldSpace = false;
  }

  void Update()
  {
    float deltaAngle = (endAngle - startAngle) / segments;
    float angle = startAngle;

    for (int i = 0; i < segments + 1; i++)
    {
      float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
      float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

      line.SetPosition(i, new Vector3(x, y, 0));

      angle += deltaAngle;
    }
  }
}
