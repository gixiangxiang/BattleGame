using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static GameManager GM;
  void Awake()
  {
    GM = this;
    DontDestroyOnLoad(this);
  }

  public void LoadScene(int sceneId)//通用加載場景方法
  {
    SceneManager.LoadScene(sceneId);
  }
}
