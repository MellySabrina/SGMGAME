using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    public Image circle;

    public void Check()
    {
        GameObject gameObject = GameObject.Find("ColorsManager");
        ColorsManager colorsManager = gameObject.GetComponent<ColorsManager>();

        if (circle.color.a == 0.75f)
        {
            Debug.Log("ACERTOUUUUUU");
            if (colorsManager.cont == 2)
            {
                Debug.Log("VOCE GANHOUU");
                foreach (Image circle in colorsManager.circleList)
                {
                    Destroy(circle.gameObject);
                    //Destroy(circle);
                }
                colorsManager.Win();
            }
            else
            {
                foreach (Image circle in colorsManager.circleList)
                {
                    Destroy(circle.gameObject);
                    //Destroy(circle);
                }
                colorsManager.cont++;
                colorsManager.circleList.Clear();
                colorsManager.InstantiateCircle();
            }

        }
        else
        {
            Debug.Log("ERROU");
        }
    }
}
