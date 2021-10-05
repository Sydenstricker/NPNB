using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCav : MonoBehaviour
{  
    [Header("Player Config")]
    [SerializeField] float velCimaBaixo = 10f;
    [SerializeField] float velEsqDir = 10f;
    [SerializeField] int health = 200;
   
    [Header("Player Audio")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float volumeMorte = 0.75f;
    
    [SerializeField] private bool puloDouble = false;
    [SerializeField] private int puloCount = 0;
    private Rigidbody2D body;
    private Animator animator;
    public float velocidade = 5;
    public float pulo = 8;
    public bool grounded;

    [SerializeField] private bool footIsGrounded = false;
   

    //os 2 sao pra barra do coracao
    public HealthBar healthBar;
    public int currentHealth;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
       
    //PI
    public int pontosIDcoletados;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {        
        PegaVidaCoracao();
        body = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        SetUpMoveBoundry();
        Move();


        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene("CavernaGameplay");
            FindObjectOfType<GameSession>().ResetGame();
            Debug.Log("deu bug socorr");
        }

        if ( Input.GetButtonDown("Jump") )
        {
            if ((puloCount == 1) && (puloDouble == true))
            {
                animator.SetTrigger("Pulando");
                
                body.velocity = new Vector2(body.velocity.x, pulo);
                puloDouble = true; //no tutorial deixar false
                puloCount = 0;
                Debug.Log("Pulo Doble funcionou");
                animator.SetBool("isGrounded",false) ;
                
            }

            if (grounded && (puloCount == 0))
            {
                animator.SetTrigger("Pulando");
               
                body.velocity = new Vector2(body.velocity.x, pulo);
                puloCount++;
                grounded = false;
                footIsGrounded = false;
                animator.SetBool("isGrounded", false);
                

                //soundManager.PlayAudio("pulo");
            }

        }

        if ( Input.GetButtonDown("Slide"))
        {
            if (grounded && footIsGrounded == true)
            {
                animator.SetTrigger("Deslizando");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = true;

                



                //body.velocity = new Vector2(body.velocity.x, pulo);
                //puloCount++;
                //soundManager.PlayAudio("pulo");
            }

          
        }       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            return;
        }
        if (other.gameObject.layer == 13)
        {
            footIsGrounded = true;
        }
        if (other.gameObject.layer == 14)
        {
            puloDouble = true;
        }
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        TomarDano(damageDealer);           
    }

    private void DesativaFoot()
    {
        this.footIsGrounded = false;
        Debug.Log("Desativou foot is Grounded");
    }

    private void FinalPuloIsGrounded()
    {
        return;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 13)
        {
            animator.SetBool("isGrounded", true);
            grounded = true;
            puloCount = 0;            
        }
        if (collision.gameObject.layer == 6)
        {
            return;
        }
    }
    
    private void AtivarBoxCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        Physics2D.gravity = new Vector2(0, -10);
        pulo = 9f;
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
    private void PegaVidaCoracao()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }
    private void TomarDano(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (damageDealer.gameObject.layer == 12)
        {
            damageDealer.PedraCaiFeliz();
        }
        else
        {
            damageDealer.Hit();
        }
            
        //currenthealth é a vida da barra com coraçao, health era ref em string
        currentHealth = health;
        healthBar.SetHealth(currentHealth);
                
        if (health <= 0)
        {
            PlayerMorreu();            
        }
        else
        {
            animator.SetTrigger("AiAi");
            //animator.SetBool("Ai", true);
        }
        return;
    }
    private void PlayerMorreu()
    {
        velocidade = 0; pulo = 0;
        animator.SetTrigger("Morreu");
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, volumeMorte);
        FindObjectOfType<Level>().LoadGameOverCav();
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetPI()
    {
        return pontosIDcoletados;
    }    
    private void Move()
    {
        // Movimento runner
        body.velocity = new Vector2(velocidade, body.velocity.y);

        var deltaY = Input.GetAxis("Vertical") * (Time.deltaTime) * velCimaBaixo;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, (yMin), yMax);

        var deltaX = Input.GetAxis("Horizontal") * (Time.deltaTime) * velEsqDir;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        //jogador anda para cima/baixo
        transform.position = new Vector2(newXPos, transform.position.y);

        //player anda direita/esquerda
        transform.position = new Vector2(transform.position.x, newYPos);                
    }
    private void SetUpMoveBoundry()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y + 2f;
    }
    public void PontosdeID()
    {
        pontosIDcoletados++;
    }
}
