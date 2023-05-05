using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Ao contr�rio de MonoBehaviour, que � usado para criar comportamentos, 
ScriptableObject � usado especificamente para armazenar dados e n�o requer
um objeto de jogo anexado para funcionar.*/    

[CreateAssetMenu(fileName = "Character_", menuName = "ScriptableObject/Character")]

public class CharacterStats : ScriptableObject
{
    public string characterName;
    public Sprite face;
}
