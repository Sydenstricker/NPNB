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

    [Header("OK VAMOS LA")]
    private bool puloDouble = false;
    private int puloCount = 0;
    private Rigidbody2D body;
    private Animator animator;
    public float velocidade = 5;
    public float pulo = 8;
    public bool grounded;
   

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
        // Movimento runner
        body.velocity = new Vector2(velocidade, body.velocity.y);

        // Pulo
        if ( Input.GetButtonDown("Jump"))
        {
            if (grounded || (puloDouble && puloCount < 2))
            {
                animator.SetTrigger("Pulando");
                body.velocity = new Vector2(body.velocity.x, pulo);
                puloCount++;
                grounded = false;
                //soundManager.PlayAudio("pulo");
            }
        }

        // Dezlizar
        if ( Input.GetButtonDown("Slide"))
        {
            if (grounded)
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
        //animator.SetFloat("Velocidade", body.velocity.x);
        //animator.SetBool("grounded", grounded);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            return;
        }
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        TomarDano(damageDealer);    
       
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
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
    }
    
    private void PegaVidaCoracao()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }
    private void TomarDano(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

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
        //Time.timeScale = 0;
        //Destroy(gameObject);
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
        //body.velocity = new Vector2(velocidade, body.velocity.y);

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
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
    public void PontosdeID()
    {
        pontosIDcoletados++;
    }
}
