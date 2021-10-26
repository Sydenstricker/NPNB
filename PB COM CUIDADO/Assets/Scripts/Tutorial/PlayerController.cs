﻿using System.Collections;
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
    public float contatempoTUT;


    [SerializeField] GameManager gameManager;
    [SerializeField] SoundManager soundManager;
    private Rigidbody2D body;
    private Animator animator;

    // Pulo duplo
    [SerializeField] private bool puloDouble = false;
    [SerializeField] private int puloCount = 0;

    [Header("Player Audio")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float volumeMorte = 0.75f;
    [SerializeField] AudioClip pulo1SFX;
    [SerializeField] [Range(0, 1)] float volumePulo1 = 0.75f;
    [SerializeField] AudioClip pulo2SFX;
    [SerializeField] [Range(0, 1)] float volumePulo2 = 0.75f;
    [SerializeField] AudioClip pulo3SFX;
    [SerializeField] [Range(0, 1)] float volumePulo3 = 0.75f;
    [SerializeField] AudioClip pulo4SFX;
    [SerializeField] [Range(0, 1)] float volumePulo4 = 0.75f;
    [SerializeField] AudioClip puloDuplo1SFX;
    [SerializeField] [Range(0, 1)] float volumePuloDuplo1 = 0.75f;
    [SerializeField] AudioClip puloDuplo2SFX;
    [SerializeField] [Range(0, 1)] float volumePuloDuplo2 = 0.75f;
    [SerializeField] AudioClip puloDuplo3SFX;
    [SerializeField] [Range(0, 1)] float volumePuloDuplo3 = 0.75f;
    [SerializeField] AudioClip puloDuplo4SFX;
    [SerializeField] [Range(0, 1)] float volumePuloDuplo4 = 0.75f;
    [SerializeField] AudioClip slideSFX;
    [SerializeField] [Range(0, 1)] float volumeSlide = 0.75f;
   

    void Start()
    {
        contatempoTUT = 0f;
        
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ContatempoUpdate();
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
                Debug.Log("Pulo Doble funcionou");
                animator.SetBool("Grounded", false);
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                var randomizadorPuloDuplo = Random.Range(0, 3);
                if (randomizadorPuloDuplo == 0) { PuloDuploSFX1(); }
                if (randomizadorPuloDuplo == 1) { PuloDuploSFX2(); }
                if (randomizadorPuloDuplo == 2) { PuloDuploSFX3(); }
                if (randomizadorPuloDuplo == 3) { PuloDuploSFX4(); }
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
                var randomizadorPulo = Random.Range(0, 3);
                if (randomizadorPulo == 0) { PuloSFX1(); }
                if (randomizadorPulo == 1) { PuloSFX2(); }
                if (randomizadorPulo == 2) { PuloSFX3(); }
                if (randomizadorPulo == 3) { PuloSFX4(); }
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
                SlideSFX();
                //gameObject.GetComponent<BoxCollider2D>().size = new Vector2 (0.01f,0.01f);
                GetComponentInChildren<BoxCollider2D>().enabled = false;
                //gameObject.GetComponent<BoxCollider2D>().enabled = false;
              

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
        if (other.tag == "MenuScoreTut")
        {
            Destroy(other.gameObject);
            gameManager.HighScoreTut();
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
        if (other.tag == "SomMorreuTut")
        {
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, volumeMorte);
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
    public float TempoDuracaoTUT()
    {        
        return contatempoTUT;
    }
    private void ContatempoUpdate()
    {
        contatempoTUT += Time.deltaTime;
    }
    private void PuloDuploSFX1()
    {
        Debug.Log("puloDuplo 1");
        AudioSource.PlayClipAtPoint(puloDuplo1SFX, Camera.main.transform.position, volumePuloDuplo1);
    }
    private void PuloDuploSFX2()
    {
        Debug.Log("puloDuplo 2");
        AudioSource.PlayClipAtPoint(puloDuplo2SFX, Camera.main.transform.position, volumePuloDuplo2);
    }
    private void PuloDuploSFX3()
    {
        Debug.Log("puloDuplo 3");
        AudioSource.PlayClipAtPoint(puloDuplo3SFX, Camera.main.transform.position, volumePuloDuplo3);
    }
    private void PuloDuploSFX4()
    {
        Debug.Log("puloDuplo 4");
        AudioSource.PlayClipAtPoint(puloDuplo4SFX, Camera.main.transform.position, volumePuloDuplo4);
    }
    private void PuloSFX1()
    {
        Debug.Log("pulo 1");
        AudioSource.PlayClipAtPoint(pulo1SFX, Camera.main.transform.position, volumePulo1);
    }
    private void PuloSFX2()
    {
        Debug.Log("pulo 2");
        AudioSource.PlayClipAtPoint(pulo2SFX, Camera.main.transform.position, volumePulo2);
    }
    private void PuloSFX3()
    {
        Debug.Log("pulo 3");
        AudioSource.PlayClipAtPoint(pulo3SFX, Camera.main.transform.position, volumePulo3);
    }
    private void PuloSFX4()
    {
        Debug.Log("pulo 4");
        AudioSource.PlayClipAtPoint(pulo4SFX, Camera.main.transform.position, volumePulo4);
    }
    private void SlideSFX()
    {
        AudioSource.PlayClipAtPoint(slideSFX, Camera.main.transform.position, volumeSlide);
    }  

}
