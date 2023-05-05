using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoorsManager : MonoBehaviour
{
    public List<GameObject> doors; //Lista de portas
    public List<GameObject> keys; //Lista de chaves 
    public List<GameObject> controls; //Lista de controles 
    public List<Color> colors1; //Lista de cores das portas
    public List<Color> colors2; //Lista de cores das chaves
    private bool[] doorStatus;
    void Start()
    {
        colors2 = colors1.ToList();
        SetDoorColor(); //Setando as cores nas portas
        SetKeysColor(); //Setando as cores nas chaves
        SetClassroomKey(); //Setando as chaves nas salas
    }
    public void SetDoorColor()
    {
        //Percorre a lista de portas
        foreach (GameObject door in doors)
        {
            //Seleciona uma cor aleatoria da "lista de cores das portas"
            int colorIndex = UnityEngine.Random.Range(0, colors1.Count);
            Color randomColor = colors1[colorIndex];
            colors1.RemoveAt(colorIndex); //Remove da lista de cores para não ser selecionada novamente
            randomColor.a = 1f;
            door.GetComponent<SpriteRenderer>().color = randomColor; //Atribui a cor na porta
        }
    }
    public void SetKeysColor()
    {
        //Percorre a lista de chaves
        foreach (GameObject key in keys)
        {
            //Seleciona uma cor aleatoria da "lista de cores das chaves"
            int colorIndex = UnityEngine.Random.Range(0, colors2.Count);
            Color randomColor = colors2[colorIndex];
            colors2.RemoveAt(colorIndex); //Remove da lista de cores para não ser selecionada novamente
            randomColor.a = 1f;
            key.GetComponent<SpriteRenderer>().color = randomColor;  //Atribui a cor na porta
        }
    }
    public void SetClassroomKey()
    {
        //Percorre a lista de portas e deixa todos os boxCollider desativado
        for (int i = 0; i < doors.Count; i++)
        {
            doors[i].GetComponent<BoxCollider2D>().enabled = false;
        }

        List<GameObject> doorsListClone = doors.ToList();
        
        //Seleciona uma porta aleatoria para ser a ultima, ou seja, a porta 5
        int doorIndex5 = UnityEngine.Random.Range(0, doorsListClone.Count);
        GameObject randomDoor5 = doorsListClone[doorIndex5];
        doorsListClone.Remove(randomDoor5);
       
        //Seleciona uma chave e atribui a cor da porta 5
        int keyIndex5 = UnityEngine.Random.Range(0, keys.Count);
        GameObject randomKey5 = keys[keyIndex5];
        keys.Remove(randomKey5);
        randomKey5.GetComponent<SpriteRenderer>().color = randomDoor5.GetComponent<SpriteRenderer>().color;
        
        //Seleciona uma porta aleatoria para ser a porta 4
        int doorIndex4 = UnityEngine.Random.Range(0, doorsListClone.Count);
        GameObject randomDoor4 = doorsListClone[doorIndex4];
        doorsListClone.Remove(randomDoor4);

        //Sala da porta 5
        Canvas openDoorCanvas5= randomDoor5.GetComponent<Doors>().classroom; //pega o a sala da porta
        RoomCanvas roomScript5 = openDoorCanvas5.GetComponent<RoomCanvas>(); //pega o script da sala 
        roomScript5.selectedControl = controls[0]; //Atribui um controle na sala

        //Sala 4 recebe chave da porta 5
        Canvas openDoorCanvas4 = randomDoor4.GetComponent<Doors>().classroom; //pega o a sala da porta
        RoomCanvas roomScript4 = openDoorCanvas4.GetComponent<RoomCanvas>(); //pega o script da sala 
        roomScript4.selectedKey = randomKey5; //O campo chave no script da sala recebe a chave que havia sido guardada
        roomScript4.selectedControl = controls[1]; //Atribui um controle na sala

        //Seleciona uma chave e atribui a cor da porta 4
        int keyIndex4 = UnityEngine.Random.Range(0, keys.Count);
        GameObject randomKey4 = keys[keyIndex4];
        keys.Remove(randomKey4);
        randomKey4.GetComponent<SpriteRenderer>().color = randomDoor4.GetComponent<SpriteRenderer>().color;
        
        //Seleciona uma porta aleatoria para ser a porta 3
        int doorIndex3 = UnityEngine.Random.Range(0, doorsListClone.Count);
        GameObject randomDoor3 = doorsListClone[doorIndex3];
        doorsListClone.Remove(randomDoor3);

        //Sala 3 recebe chave da porta 4
        Canvas openDoorCanvas3 = randomDoor3.GetComponent<Doors>().classroom; //pega o a sala da porta
        RoomCanvas roomScript3 = openDoorCanvas3.GetComponent<RoomCanvas>(); //pega o script da sala 
        roomScript3.selectedKey = randomKey4; //O campo chave no script da sala recebe a chave que havia sido guardada
        roomScript3.selectedControl = controls[2]; //Atribui um controle na sala

        //Seleciona uma chave e atribui a cor da porta 3
        int keyIndex3 = UnityEngine.Random.Range(0, keys.Count);
        GameObject randomKey3 = keys[keyIndex3];
        keys.Remove(randomKey3);
        randomKey3.GetComponent<SpriteRenderer>().color = randomDoor3.GetComponent<SpriteRenderer>().color;

        //Seleciona uma porta aleatoria para ser a porta 2
        int doorIndex2 = UnityEngine.Random.Range(0, doorsListClone.Count);
        GameObject randomDoor2 = doorsListClone[doorIndex2];
        doorsListClone.Remove(randomDoor2);

        //Sala 2 recebe chave da porta 3
        Canvas openDoorCanvas2 = randomDoor2.GetComponent<Doors>().classroom; //pega o a sala da porta
        RoomCanvas roomScript2 = openDoorCanvas2.GetComponent<RoomCanvas>(); //pega o script da sala 
        roomScript2.selectedKey = randomKey3; //O campo chave no script da sala recebe a chave que havia sido guardada
        roomScript2.selectedControl = controls[3]; //Atribui um controle na sala

        //Seleciona uma porta aleatoria para ser a porta 1
        int doorIndex1 = UnityEngine.Random.Range(0, doorsListClone.Count);
        GameObject randomDoor1 = doorsListClone[doorIndex1];
        doorsListClone.Remove(randomDoor1);

        //Seleciona uma chave e atribui a cor da porta 2
        int keyIndex2 = UnityEngine.Random.Range(0, keys.Count);
        GameObject randomKey2 = keys[keyIndex2];
        keys.Remove(randomKey2);
        randomKey2.GetComponent<SpriteRenderer>().color = randomDoor2.GetComponent<SpriteRenderer>().color;

        //Sala 1 recebe chave da porta 2
        Canvas openDoorCanvas1 = randomDoor1.GetComponent<Doors>().classroom; //pega o a sala da porta
        RoomCanvas roomScript1 = openDoorCanvas1.GetComponent<RoomCanvas>(); //pega o script da sala 
        roomScript1.selectedKey = randomKey2; //O campo chave no script da sala recebe a chave que havia sido guardada
        roomScript1.selectedControl = controls[4]; //Atribui um controle na sala

        randomDoor1.GetComponent<BoxCollider2D>().enabled = true;
    }
}
