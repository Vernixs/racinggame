using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    void start()
    {
        panel.SetActive(false);
    }
    public void PlayButton()
    {
        panel.SetActive(true);
       
    }

    public void OptionsButton()
    {
        optionsMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("exit");
    }

    public void BackButton()
    {
        panel.SetActive(false);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void trackButton()
    {
        SceneManager.LoadScene(0);
    }
}
