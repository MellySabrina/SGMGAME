using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public int randomNumber; //referência ao número aleatório gerado anteriormente
    public InputField inputField; //referência à caixa de entrada

    void Start()
    {

            inputField.characterLimit = 4; //limita o número de caracteres a 4
            inputField.text = randomNumber.ToString(); //define o número aleatório gerado anteriormente como o valor do campo de entrada
    }

 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inputField.gameObject.SetActive(true); // Ativa o InputField
        }
    }

   public void CheckNumber()
{
        int numeroDigitado = int.Parse(inputField.text);
        inputField.gameObject.SetActive(false); // Desativa o InputField

        if (numeroDigitado == randomNumber)
        {
            Debug.Log("Acertou!");
        }
        else
        {
            Debug.Log("Errou!");
        }
    }
}
