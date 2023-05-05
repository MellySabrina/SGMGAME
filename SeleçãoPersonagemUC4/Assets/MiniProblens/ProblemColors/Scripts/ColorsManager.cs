using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorsManager : MonoBehaviour
{
    public Image[,] grid; //grade
    public float space; //espaço entre as cartas
    public Image circle;
    public Transform canvas;
    public List<Image> circleList; // lista de circulos
    public List<Color> colorsList; // lista de cores
    public int cont = 0;

    public GameObject popUpPrefab;
    private GameObject popUpInstance;

    void Start()
    {
        InstantiateCircle();
    }
    public void InstantiateCircle()
    {
        grid = new Image[2, 6];

        for (int row = 0; row < 2; row++)
        {
            for (int col = 0; col < 6; col++)
            {
                Vector3 pos = new Vector3(col - 6 / 2f + 0.5f, row - 2 / 2f + 0.1f, 0) * space;
                Image newCircle = Instantiate(circle, canvas);
                newCircle.transform.localPosition = pos;
                circleList.Add(newCircle);
            }
        }

        int colorIndex = UnityEngine.Random.Range(0, colorsList.Count);
        Color randomColor = colorsList[colorIndex];
        randomColor.a = 1f;
        colorsList.RemoveAt(colorIndex);
        foreach (Image circle in circleList)
        {
            circle.GetComponent<Image>().color = randomColor;
        }
        int circleIndex = UnityEngine.Random.Range(0, circleList.Count);
        Image randomCircle = circleList[circleIndex];
        randomColor.a = 0.75f;
        randomCircle.GetComponent<Image>().color = randomColor;
    }
    public void Win()
    {
        popUpInstance = Instantiate(popUpPrefab, canvas);

    }
    private void Update()
    {

    }

}
