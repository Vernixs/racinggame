using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    void start()
    {
        panel.SetActive(false);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(0);
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
        SceneManager.LoadScene(0);
    }
}
