using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Elevators : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform teleportPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pressione F para trocar de cena.");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            player.position = teleportPosition.position;

        }
    }
}
