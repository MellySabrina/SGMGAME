using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEditor.Animations;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;


public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private float speed = 6;
    [SerializeField] private float jumpForce;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public AnimatorController graziAnimation;
    public AnimatorController mattAnimation;
    public AnimatorController mellyAnimation;
    public Sprite graziSpriteStopped;
    public Sprite mattSpriteStopped;
    public Sprite mellySpriteStopped;
    public Sprite graziSpriteJump;
    public Sprite mattSpriteJump;
    public Sprite mellySpriteJump;

    [SerializeField] private float horizontal;
    [SerializeField] private bool jump;
    [SerializeField] private bool isGrounded = false;
    private int contKey = 0;
    private int contControl = 0;
    private int life = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private Rigidbody2D rb;

    PlayerInputActions input;

    private PlayerInput playerInput;

    public GameObject completedLevel;
    public DoorsManager doorsManager;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;
    public GameObject control1;
    public GameObject control2;
    public GameObject control3;
    public GameObject control4;
    public GameObject control5;
    public GameObject teacher;


    private void Awake()
    {
        input = new PlayerInputActions();
        jumpForce = 5.5f;
        playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SpriteMoviment(graziSpriteStopped, mattSpriteStopped, mellySpriteStopped);
    }

    private void OnEnable() // executado quando um objeto é ativado
    {
        input.Enable();
    }

    private void OnDisable() //quando desativado
    {
        input.Disable();
    }

    public void DisableInput()
    {
        playerInput.enabled = false;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        jump = context.performed;
        isGrounded = false;
        SpriteMoviment(graziSpriteJump, mattSpriteJump, mellySpriteJump);
    }

    void OnCollisionStay2D(Collision2D collision) // verifica se ta no chao
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            SpriteMoviment(graziSpriteStopped, mattSpriteStopped, mellySpriteStopped);
        }
    }

    public void SetMoviment(InputAction.CallbackContext context) //direita e esquerda
    {
        horizontal = context.ReadValue<float>();
        if (horizontal < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (isGrounded && jump)
        {
            jump = false;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
        if (isGrounded && horizontal != 0 && !jump)
        {
            Walking();
        }
        else
        {
            animator.runtimeAnimatorController = null;
        }

    }
    public void Disappear()
    {
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 1f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BadGrade"))
        {
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0.5f);

            Invoke("Disappear", 0.5f);
            life--;
            if (life == 2)
            {
                heart3.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            }
            else if (life == 1)
            {
                heart2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
                heart3.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            }
            else
            {
                Debug.Log("Voce perdeu!");
                SceneManager.LoadScene("Level1");
                heart1.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
                heart2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
                heart3.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            }
        }

        if (collision.gameObject.CompareTag("Prof"))
        {
            DisableInput();
            completedLevel.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Set"))
        {
            DisableInput();
            completedLevel.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            contKey++;
            Debug.Log(contKey);

            if (contKey == 1)
            {
                Destroy(collision.gameObject);
                //collision.gameObject.SetActive(false);
                key1.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            }
            else if (contKey == 2)
            {
                Destroy(collision.gameObject);
                //collision.gameObject.SetActive(false);
                key2.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            }
            else if (contKey == 3)
            {
                Destroy(collision.gameObject);
                //collision.gameObject.SetActive(false);
                key3.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            }
            else if (contKey == 4)
            {
                Destroy(collision.gameObject);
                //ollision.gameObject.SetActive(false);
                key4.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            }
            foreach (GameObject d in doorsManager.doors)
            {
                if (d.GetComponent<SpriteRenderer>().color == collision.gameObject.GetComponent<SpriteRenderer>().color)
                {
                    d.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }
        if (collision.gameObject.CompareTag("Control"))
        {
            contControl++;
            Debug.Log(contControl);

            if (contControl == 1)
            {
                Destroy(collision.gameObject);
                control1.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            }
            else if (contControl == 2)
            {
                Destroy(collision.gameObject);
                control2.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            }
            else if (contControl == 3)
            {
                Destroy(collision.gameObject);
                control3.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            }
            else if (contControl == 4)
            {
                Destroy(collision.gameObject);
                control4.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            }
            else if (contControl == 5)
            {
                teacher.SetActive(true);
                Destroy(collision.gameObject);
                control5.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            }

        }
    }
    public void Walking()
    {
        string charName = PlayerPrefs.GetString("characterName");

        switch (charName)
        {
            case "Grazi":
                animator.runtimeAnimatorController = graziAnimation;
                break;
            case "Matt":
                animator.runtimeAnimatorController = mattAnimation;
                break;
            case "Melly":
                animator.runtimeAnimatorController = mellyAnimation;
                break;
            default:
                // Nenhuma animação para este personagem
                break;
        }
    }
    public void SpriteMoviment(Sprite spriteGrazi, Sprite spriteMatt, Sprite spriteMelly)
    {
        string charName = PlayerPrefs.GetString("characterName");

        switch (charName)
        {
            case "Grazi":
                GetComponent<BoxCollider2D>().offset = new Vector2(0.17f, -0.22f);
                GetComponent<BoxCollider2D>().size = new Vector2(0.51f, 0.65f);
                transform.localScale = new Vector2(1.3f, 1.3f);
                spriteRenderer.sprite = spriteGrazi;
                break;
            case "Matt":
                GetComponent<BoxCollider2D>().offset = new Vector2(-0.05f,-0.59f);
                GetComponent<BoxCollider2D>().size = new Vector2(1.11f,1.9f);
                transform.localScale = new Vector2(0.44f, 0.44f);
                spriteRenderer.sprite = spriteMatt;
                break;
            case "Melly":
                GetComponent<BoxCollider2D>().offset = new Vector2(0.2f,-0.6f);
                GetComponent<BoxCollider2D>().size = new Vector2(1.3f, 1.7f);
                transform.localScale = new Vector2(0.44f, 0.44f);
                spriteRenderer.sprite = spriteMelly;
                break;
            default:
                break;
        }
    }
}
