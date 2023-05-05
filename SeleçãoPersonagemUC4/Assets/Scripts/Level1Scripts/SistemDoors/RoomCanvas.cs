using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomCanvas : MonoBehaviour
{
    public GameObject selectedKey; // chave selecionada pelo jogador
    public GameObject selectedControl;
    public void DisplaySelectedKey()
    {
        Debug.Log("A chave selecionada é: " + selectedKey.GetComponent<SpriteRenderer>().color);
        // Aqui você pode adicionar mais código para exibir a chave na tela, mudar a cor do objeto da chave, etc.
    }
}
