using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject backbutton;
    public GameObject track1button;
    public GameObject panel;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject loadingScreen;
    void start()
    {
        panel.SetActive(false);
        track1button.SetActive(false);
        backbutton.SetActive(false);
    }
    public void PlayButton()
    {
        track1button.SetActive(true);
        backbutton.SetActive(true);
        panel.SetActive(true);
        optionsMenu.SetActive(false);

       
    }

    public void OptionsButton()
    {
        track1button.SetActive(false);
        optionsMenu.SetActive(true);
        panel.SetActive(false);
        backbutton.SetActive(false);
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
        track1button.SetActive(false);
        backbutton.SetActive(false);
    }

    public void trackButton()
    {
        SceneManager.LoadScene(1);
        panel.SetActive(false);
        loadingScreen.SetActive(true);
    }
}
