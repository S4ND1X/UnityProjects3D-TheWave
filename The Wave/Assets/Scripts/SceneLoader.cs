using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
  
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1; // Set back the time scale to 1
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
