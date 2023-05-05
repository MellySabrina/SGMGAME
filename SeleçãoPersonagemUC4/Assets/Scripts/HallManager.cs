using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HallManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pause;
    public PlayerMoviment playerMoviment;
    public void OpenPause()
    {
        pausePanel.SetActive(true);
        pause.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ContinuePause()
    {
        pausePanel.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 1f;


    }
    public void RestartPause(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
        Time.timeScale = 1f;

    }

    public void ExitPause(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }


}
