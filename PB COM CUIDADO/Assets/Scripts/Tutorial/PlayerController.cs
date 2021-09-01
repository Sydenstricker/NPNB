using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;
    [SerializeField] float pulo = 8;
    [SerializeField] bool grounded;
    [SerializeField] bool podeSlide = false;
    [SerializeField] public bool isDialogNaoPulaCacete = true;

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
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            if (puloDouble == false)
            {
                animator.SetTrigger("Pulando");
                body.velocity = new Vector2(body.velocity.x, pulo);
                puloCount++;
                soundManager.PlayAudio("pulo");
            }
            if ((puloDouble = true) && (puloCount < 2))
            {
                animator.SetTrigger("Pulando");
                body.velocity = new Vector2(body.velocity.x, pulo);
                //puloCount++;
                //soundManager.PlayAudio("pulo");
            }
           
            
        }
        // Deslizar
        if (Input.GetButtonDown("Slide"))
        {
            if (grounded && podeSlide == true)
            {
                animator.SetTrigger("Deslizando");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Physics2D.gravity = new Vector2(0, 0);
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
    //Colisão
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = true;
            puloCount = 0;
        }
        switch (collision.gameObject.tag)
        {
            case "Dead":
            case "Obstaculo":
                soundManager.PlayAudio("obstaculocolission");
                
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
        
        else if (other.tag == "SlideFDP")
        {
            podeSlide = true;
        }

        else if (other.tag == "PuloDuplo")
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
