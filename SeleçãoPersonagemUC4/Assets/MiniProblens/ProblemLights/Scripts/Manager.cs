using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static public Manager instance;
    public Transform canvas;
    public int buttonsCount;
    public GameObject background;
    private int onCount = 0;

    public GameObject popUpPrefab;
    private GameObject popUpInstance;


    private void Awake()
    {
        instance = this;
    }
    public void ButtonsChange(int points)
    {
        onCount += points;
        if (onCount == buttonsCount)
        {
            
            background.SetActive(false);
            popUpInstance = Instantiate(popUpPrefab, canvas);

        }
    }
}
