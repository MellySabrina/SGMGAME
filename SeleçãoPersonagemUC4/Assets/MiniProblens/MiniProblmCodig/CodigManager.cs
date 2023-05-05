using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodigManager : MonoBehaviour
{
    public TextMeshProUGUI numberText; //refer�ncia ao texto onde o n�mero ser� exibido
    public int randomNumber; //vari�vel para armazenar o n�mero aleat�rio gerado


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            randomNumber = Random.Range(1000, 10000); //gera um n�mero aleat�rio entre 1000 e 9999
            numberText.text = "N�mero: " + randomNumber.ToString(); //exibe o n�mero no texto
        }
    }
}
