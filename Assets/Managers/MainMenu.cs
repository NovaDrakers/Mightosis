using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject settingsPanel;
    public GameObject mainMenu;
    public GameObject skipTutorialsPanel;
    
    public void openSettings()
    {
        settingsPanel.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void backButton()
    {
        settingsPanel.SetActive(false);
        skipTutorialsPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void skipTutorials()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void initialStart()
    {
        skipTutorialsPanel.SetActive(true);
    }

    public void startGame()
    {
        SceneManager.LoadScene("BuildingTutorial");
    }
}
