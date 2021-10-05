using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;
    [SerializeField] float pulo = 8;
    [SerializeField] bool grounded;
    [SerializeField] bool podeSlide = false;
    [SerializeField] bool podePular = false;
    [SerializeField] private bool footIsGrounded = false;


    [SerializeField] GameManager gameManager;
    [SerializeField] SoundManager soundManager;
    private Rigidbody2D body;
    private Animator animator;

    // Pulo duplo
    [SerializeField] private bool puloDouble = false;
    [SerializeField] private int puloCount = 0;    

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimento runner
        body.velocity = new Vector2(velocidade, body.velocity.y);
        
        // Pulo
        if (Input.GetButtonDown("Jump") && (podePular == true))
        {
            if ((puloCount == 1) && (puloDouble == true))
            {
                animator.SetTrigger("Pulando");
                body.velocity = new Vector2(body.velocity.x, pulo);
                puloDouble = true; //no tutorial deixar false
                puloCount = 0;
                soundManager.PlayAudio("puloduplo");
                Debug.Log("Pulo Doble funcionou");
                animator.SetBool("Grounded", false);
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            }

            if (grounded && (puloCount == 0))
            {
                animator.SetTrigger("Pulando");
                body.velocity = new Vector2(body.velocity.x, pulo);
                puloCount++;
                grounded = false;
                footIsGrounded = false;
                animator.SetBool("Grounded", false);
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                //soundManager.PlayAudio("pulo");
            }
            //if (podePular == true)
            {
                //animator.SetTrigger("Pulando");
                //body.velocity = new Vector2(body.velocity.x, pulo);
                //puloCount++;
                //soundManager.PlayAudio("pulo");
            }
            //if ((puloDouble = true) && (puloCount < 2))
            {
               // animator.SetTrigger("Pulando");
                //body.velocity = new Vector2(body.velocity.x, pulo);
                //puloCount++;
                //soundManager.PlayAudio("pulo");
            }
                        
        }

        if (Input.GetButtonDown("Restart"))
            {
                SceneManager.LoadScene("Tutorial");
                Debug.Log("deu bug socorr");
            }
        // Deslizar
        if (Input.GetButtonDown("Slide"))
        {
            if (grounded && podeSlide == true)
            {
                animator.SetTrigger("Deslizando");
                //gameObject.GetComponent<BoxCollider2D>().size = new Vector2 (0.01f,0.01f);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
              

                //body.velocity = new Vector2(body.velocity.x, pulo);
                //puloCount++;
                //soundManager.PlayAudio("pulo");
            }
        }
        // Animação
        animator.SetFloat("Velocidade", body.velocity.x);
        animator.SetBool("Grounded", grounded);

        //Pinky em posição idle no tutorial
        if (DialogueCutsceneManager.isActive == true)
        {
            ParaPinkTutorial();
        }
        if (DialogueCutsceneManager.isActive == false)
        {
            AndaPinkTutorial();
        }

    }

    private void AtivarCapsuleCollider()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        Physics2D.gravity = new Vector2(0, -10);
        pulo = 9f;
    }

    private void DestivarCapsuleCollider()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        Physics2D.gravity = new Vector2(0, -10);
        pulo = 9f;
    }
    //Colisão
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            animator.SetBool("Grounded", true);
            grounded = true;
            puloCount = 0;
        }
        switch (collision.gameObject.tag)
        {
            case "Dead":
            case "Obstaculo":
                soundManager.PlayAudio("obstaculocolision");
                
                gameManager.RestartGame();
                break;
        }         

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
            grounded = false;
    }
    private void AtivarBoxColliderTut()
    {
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1f, 2f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        Physics2D.gravity = new Vector2(0, -10);
    }

    //Triggers
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Moeda")
        {
            Destroy(other.gameObject);
            gameManager.AddPontos(10);
            soundManager.PlayAudio("moeda");
        }

        if (other.gameObject.layer == 0)
        {
            footIsGrounded = true;
        }
        if (other.tag == "SlideFDP")
        {
            podeSlide = true;
        }
        if (other.tag == "PulaFDP")
        {
            podePular = true;
        }

        if (other.tag == "PuloDuplo")
        {
            Destroy(other.gameObject);
            puloDouble = true;
            //soundManager.PlayAudio("puloduplo");

        }
        
    }
    
    //Parar e seguir no tutorial
    private void ParaPinkTutorial()
    {
        body.velocity = new Vector2(0, 0);
        animator.SetFloat("Velocidade", 0);
    }
    private void AndaPinkTutorial()
    {
        body.velocity = new Vector2(velocidade, body.velocity.y);
        animator.SetFloat("Velocidade", body.velocity.x);
    }

}
