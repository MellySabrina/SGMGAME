using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevelManager : MonoBehaviour
{
    public GameObject completedLevel;
    public int levelNumber = 0;

    void Start()
    {
        levelNumber = PlayerPrefs.GetInt("levelCompleted", 0);

    }

    //botoes
    public void Restart(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
        DisablePadlock();
    }

    public void NextLevel(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
        DisablePadlock();
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene("SelectLevel");
        DisablePadlock();

    }

    public void CompleteLevel(int level)
    {
        if (level > levelNumber)
        {
            levelNumber = level;
            PlayerPrefs.SetInt("levelCompleted", levelNumber);
        }

    }
    public void DisablePadlock() //desativa o cadeado //ativa o completo do level 1
    {
        PlayerPrefs.SetInt("isPadlockActive", 0); // Define o valor da chave como 0 (falso)
        PlayerPrefs.SetInt("isCompleteActive", 1); // Define como 1 (verdadeiro)
    }
}
