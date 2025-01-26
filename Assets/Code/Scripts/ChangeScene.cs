using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
