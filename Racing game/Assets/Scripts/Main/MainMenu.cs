using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    public GameObject mainMenu;
    void start()
    {
        panel.SetActive(false);
    }
    public void PlayButton()
    {
        panel.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene(1);
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
    }

    public void trackButton()
    {
        SceneManager.LoadScene(0);
    }
}
