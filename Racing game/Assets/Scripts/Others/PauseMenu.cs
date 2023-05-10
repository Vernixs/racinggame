using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject dialogue;
    private void Start()
    {
        pausePanel.SetActive(false);
        dialogue.SetActive(true);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pause");
            dialogue.SetActive(false);
            pausePanel.SetActive(true);
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        dialogue.SetActive(true);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(1);
    }

}
