using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] CharacterPanel characterPanelLeft;
    [SerializeField] CharacterPanel characterPanelMiddle;
    [SerializeField] CharacterPanel characterPanelRight;
    void Start()
    {
        CharacterList.instance.SelectedCharIndex = 0;
        UpdateCharacterPanels();
    }
    private void UpdateCharacterPanels()
    {
        characterPanelLeft.UpdateCharacterPanel(CharacterList.instance.GetPrevious());
        characterPanelMiddle.UpdateCharacterPanel(CharacterList.instance.currentCharacter);
        characterPanelRight.UpdateCharacterPanel(CharacterList.instance.GetNext());
    }
    public void LeftButton()
    {
        CharacterList.instance.SelectedCharIndex--;
        Debug.Log("left");
        UpdateCharacterPanels();
    }

    public void RightButton()
    {
        CharacterList.instance.SelectedCharIndex++;
        Debug.Log("right");
        UpdateCharacterPanels();
    }
    public void Continue()
    {
        PlayerPrefs.SetString("characterName", CharacterList.instance.currentCharacter.characterName);
        PlayerPrefs.Save();
        SceneManager.LoadScene("SelectLevel");
    }

    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }
}
