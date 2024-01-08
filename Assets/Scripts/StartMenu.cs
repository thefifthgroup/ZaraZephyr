using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
  public void StarGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildingIndex + 1);
  }
}
