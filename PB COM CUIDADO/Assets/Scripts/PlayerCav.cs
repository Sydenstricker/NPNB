using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCav : MonoBehaviour
{
    [Header("Player Config")]
    [SerializeField] float velCimaBaixo = 10f;
    [SerializeField] float velEsqDir = 10f;
    [SerializeField] float limiteTela = 1f;
    [SerializeField] int health = 200;
    [SerializeField] int scoreValue = 150;

    [Header("Player Audio")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float volumeMorte = 0.75f;
   
    // Pulo duplo
    private bool puloDouble = false;
    private int puloCount = 0;

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
    void Start()
    {
        SetUpMoveBoundry();
        PegaVidaCoracao();
    }

    void Update()
    {
        Move();        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        TomarDano(damageDealer);

        if (other.tag == "Moeda")
        {
            Destroy(other.gameObject);
            FindObjectOfType<GameSession>().AddToScore(scoreValue); 
            
        }
        else if (other.tag == "PuloDuplo")
        {
            Destroy(other.gameObject);
            puloDouble = true;
           // soundManager.PlayAudio("puloduplo");

        }

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
    }
    private void PlayerMorreu()
    {
        Destroy(gameObject);
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
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + limiteTela;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - limiteTela;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + limiteTela;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - limiteTela;
    }    
    public void PontosdeID()
    {
        pontosIDcoletados++;
    }
}
