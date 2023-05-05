using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{
    private Collider2D doorCollider = null;
    public GameObject doorA = null;
    public GameObject doorB = null;
    public GameObject doorC = null;
    public GameObject doorD = null;
    public GameObject door = null;
    public GameObject limits = null;
    public GameObject elevators = null;
    public GameObject numbers = null;
    public Canvas classroom = null;

    //public AnimationClip animationDoor;

    private bool d = false;
    private bool c = true;
    private void Awake()
    {
        doorCollider = GetComponent<Collider2D>();
    }
    void Start()
    {
        //animationDoor = GetComponent<AnimationClip>();
        //animationDoor.enable = false;
    }

    //Quando o player colidir com a porta, imprime uma mensaagem
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pressione espaço para trocar de cena.");
        }
    }

    //Quando pressionar "espaço", entra na sala
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            //Animator anim = GetComponent<Animator>();
            //anim.SetTrigger("OpenDoor");

            //animationDoor.enabled = true;
            //animationDoor.Play();

            doorA.SetActive(d);
            doorB.SetActive(d);
            doorC.SetActive(d);
            doorD.SetActive(d);
            door.SetActive(true);
            limits.SetActive(d);
            elevators.SetActive(d);
            numbers.SetActive(d);

            classroom.gameObject.SetActive(c);
            RoomCanvas roomScript = classroom.gameObject.GetComponent<RoomCanvas>(); //pega o script da sala 

            if (roomScript.selectedKey != null)
            {
                roomScript.selectedKey.SetActive(c);
            }
            if (roomScript.selectedControl != null)
            {
                roomScript.selectedControl.SetActive(c);
            }
            c = !c;
            d = !d;
        }
    }
}






