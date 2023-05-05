using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;


public class SelectLevel : MonoBehaviour
{
    public GameObject padlock;
    public GameObject level1Complete;
    public GameObject level1Incomplete;
    public GameObject level2Complete;
    public GameObject level2Incomplete;
    public GameObject selectLevelPanel;
    public GameObject settingsPanel;

    void Start()
    {
        bool isPadlockActive = PlayerPrefs.GetInt("isPadlockActive", 1) == 1; // Obtém o valor da chave e converte para booleano
        padlock.SetActive(isPadlockActive); // Define o estado ativo do cadeado GameObject

        bool isCompleteActive = PlayerPrefs.GetInt("isCompleteActive", 0) == 1; // Obtém o valor da chave e converte para booleano
        level1Complete.SetActive(isCompleteActive);  // Define o estado do level 1 completo

    }

    public void OpenSettings()
    {
        selectLevelPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void BackCharacterSelection()
    {
        SceneManager.LoadScene("SelectCharacter");
    }

    public void StarLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1f;


    }
    /*
    public void StarLevel2(string levelName)
    {
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1f;
    
    }*/
    /*
    public void DisablePadlock()
    {
        padlock.SetActive(false);
    }*/
}
