using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseScreenScript : MonoBehaviour
{
    public void tryAgain()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}