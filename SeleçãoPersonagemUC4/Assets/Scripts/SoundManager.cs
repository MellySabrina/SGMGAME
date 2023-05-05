using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public bool statusSound = true;
    public AudioSource backgroundSound;
    public Sprite soundActivated;
    public Sprite soundDesactivated;
    public Image image;
    void Start()
    {
        Debug.Log("Volume" + float.Parse(PlayerPrefs.GetString("sound")));
        float value = float.Parse(PlayerPrefs.GetString("sound"));
        backgroundSound.volume = value;
    }
    public void ActiveOrDesactiveSound()
    {
        statusSound = !statusSound;
        backgroundSound.enabled = statusSound;

        if (statusSound)
        {
            image.sprite = soundActivated;
        }
        else
        {
            image.sprite = soundDesactivated;
        }
    }
}
