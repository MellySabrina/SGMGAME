using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodigManager : MonoBehaviour
{
    public TextMeshProUGUI numberText; //referência ao texto onde o número será exibido
    public int randomNumber; //variável para armazenar o número aleatório gerado


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            randomNumber = Random.Range(1000, 10000); //gera um número aleatório entre 1000 e 9999
            numberText.text = "Número: " + randomNumber.ToString(); //exibe o número no texto
        }
    }
}
