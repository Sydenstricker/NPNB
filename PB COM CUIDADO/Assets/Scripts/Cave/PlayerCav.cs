using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCav : MonoBehaviour
{
    [Header("Player Config")]
    [SerializeField] float velCimaBaixo = 10f;
    [SerializeField] float velEsqDir = 10f;
    [SerializeField] int health = 200;
    [SerializeField] GameObject aguaSplash;

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
    [SerializeField] AudioClip dano1SFX;
    [SerializeField] [Range(0, 1)] float volumeDano1 = 0.75f;
    [SerializeField] AudioClip dano2SFX;
    [SerializeField] [Range(0, 1)] float volumeDano2 = 0.75f;
    [SerializeField] AudioClip dano3SFX;
    [SerializeField] [Range(0, 1)] float volumeDano3 = 0.75f;


    [SerializeField] private bool puloDouble = false;
    [SerializeField] private int puloCount = 0;
    [SerializeField] GameManager gameManager;
    private Rigidbody2D body;
    private Animator animator;
    public float velocidade = 5;
    public float pulo = 8;
    public bool grounded;
    public float contatempoCAV;

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
        Cursor.visible = false;
        contatempoCAV = 0;
        PegaVidaCoracao();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ContatempoUpdateCAV();
        SetUpMoveBoundry();
        Move();

        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene("CavernaGameplay");
            FindObjectOfType<GameSession>().ResetGame();
        }

        if (Input.GetButtonDown("Jump"))
        {
            if ((puloCount == 1) && (puloDouble == true))
            {
                FinalSlideEvitaBugsColliders();
                animator.SetTrigger("PULODUPLO");

                body.velocity = new Vector2(body.velocity.x, pulo);
                puloDouble = true; //no tutorial deixar false
                puloCount = 0;
                animator.SetBool("isGrounded", false);
                RandomizaSFXPuloDuplo();
            }

            if (grounded && (puloCount == 0) && footIsGrounded)
            {
                FinalSlideEvitaBugsColliders();
                animator.SetTrigger("Pulando");

                body.velocity = new Vector2(body.velocity.x, pulo);
                puloCount++;
                grounded = false;
                footIsGrounded = false;
                animator.SetBool("isGrounded", false);
                RandomizaSFXPulo();
            }
        }

        if (Input.GetButtonDown("Slide"))
        {
            if (grounded && footIsGrounded == true)
            {
                puloCount = 0;
                animator.SetTrigger("Deslizando");
                //gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                GameObject.Find("PlayerCollCav").GetComponent<CapsuleCollider2D>().enabled = true;
                GameObject.Find("PlayerCollCav").GetComponent<BoxCollider2D>().enabled = false;
                //gameObject.GetComponent<BoxCollider2D>().enabled = false;
                animator.SetBool("isGrounded", true);
                grounded = true;
                SlideSFX();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 13)
        {
            animator.SetBool("isGrounded", true);
            grounded = true;
            puloCount = 0;
        }

        if (other.tag == "MenuScoreCav" && pontosIDcoletados >= 3)
        {
            FindObjectOfType<cameraMovCav>().AtivaGlitchScore();
            gameManager.HighScoreCav();
            Destroy(other.gameObject);

        }
        if (other.tag == "MenuScoreCav" && pontosIDcoletados < 3)
        {
            FindObjectOfType<cameraMovCav>().AtivaGlitchScore();
            Destroy(other.gameObject);
            gameManager.PIMenuCav();
        }
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
    }

    private void FinalSlideEvitaBugsColliders()
    {
        GameObject.Find("PlayerCollCav").GetComponent<BoxCollider2D>().enabled = true;
        GameObject.Find("PlayerCollCav").GetComponent<CapsuleCollider2D>().enabled = false;
        //gameObject.GetComponent<BoxCollider2D>().enabled = true ;
        //gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }
    private void DesativaRigidBody()
    {
        Destroy(body); //seria legal desligar
    }
    private void AtivaRigidBody()
    {
        gameObject.AddComponent<Rigidbody>(); // erro polygon collider, caos
    }
    private void FinalPuloIsGrounded()
    {
        return;
    }


    private void PegaVidaCoracao()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }
    private void TomarDano(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        RandomizaDanoSFX();
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
            return;
        }
        else
        {
            animator.SetTrigger("AiAi");
        }
        return;
    }

    private void RandomizaDanoSFX()
    {
        var randomizadorDano = Random.Range(0, 3);
        if (randomizadorDano == 0) { Dano1SFX(); }
        if (randomizadorDano == 1) { Dano2SFX(); }
        if (randomizadorDano == 2) { Dano3SFX(); }
    }
    private void RandomizaSFXPuloDuplo()
    {
        var randomizadorPuloDuplo = Random.Range(0, 4);
        if (randomizadorPuloDuplo == 0) { PuloDuploSFX1(); }
        if (randomizadorPuloDuplo == 1) { PuloDuploSFX2(); }
        if (randomizadorPuloDuplo == 2) { PuloDuploSFX3(); }
        if (randomizadorPuloDuplo == 3) { PuloDuploSFX4(); }
    }

    private void RandomizaSFXPulo()
    {
        var randomizadorPulo = Random.Range(0, 4);
        if (randomizadorPulo == 0) { PuloSFX1(); }
        if (randomizadorPulo == 1) { PuloSFX2(); }
        if (randomizadorPulo == 2) { PuloSFX3(); }
        if (randomizadorPulo == 3) { PuloSFX4(); }
    }

    private void PlayerMorreu()
    {
        FindObjectOfType<PauseMenu>().PlayerMorreuNaoPermitirPausa();
        velocidade = 0; pulo = 0;
        animator.SetTrigger("Morreu");
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, volumeMorte);
        FindObjectOfType<GamePlayCavernaCanvas>().RestartGame();
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
    public void AtivaAguaSplash()
    {
        //aguaSplash.gameObject.SetActive(true); STANDBY ESSE FOI O ULTIMO A SER USADO
        //GameObject aguaVFX = Instantiate(aguaSplash, transform.position, transform.rotation) as GameObject;        
        Debug.Log("fez VFX Agua");
    }
    public void PontosdeID()
    {
        pontosIDcoletados++;
    }
    public float TempoDuracaoCAV()
    {
        return contatempoCAV;
    }
    private void ContatempoUpdateCAV()
    {
        contatempoCAV += Time.deltaTime;
    }
    private void PuloDuploSFX1()
    {
        AudioSource.PlayClipAtPoint(puloDuplo1SFX, Camera.main.transform.position, volumePuloDuplo1);
    }
    private void PuloDuploSFX2()
    {
        AudioSource.PlayClipAtPoint(puloDuplo2SFX, Camera.main.transform.position, volumePuloDuplo2);
    }
    private void PuloDuploSFX3()
    {
        AudioSource.PlayClipAtPoint(puloDuplo3SFX, Camera.main.transform.position, volumePuloDuplo3);
    }
    private void PuloDuploSFX4()
    {
        AudioSource.PlayClipAtPoint(puloDuplo4SFX, Camera.main.transform.position, volumePuloDuplo4);
    }
    private void PuloSFX1()
    {
        AudioSource.PlayClipAtPoint(pulo1SFX, Camera.main.transform.position, volumePulo1);
    }
    private void PuloSFX2()
    {
        AudioSource.PlayClipAtPoint(pulo2SFX, Camera.main.transform.position, volumePulo2);
    }
    private void PuloSFX3()
    {
        AudioSource.PlayClipAtPoint(pulo3SFX, Camera.main.transform.position, volumePulo3);
    }
    private void PuloSFX4()
    {
        AudioSource.PlayClipAtPoint(pulo4SFX, Camera.main.transform.position, volumePulo4);
    }
    private void SlideSFX()
    {
        AudioSource.PlayClipAtPoint(slideSFX, Camera.main.transform.position, volumeSlide);
    }
    private void Dano1SFX()
    {
        AudioSource.PlayClipAtPoint(dano1SFX, Camera.main.transform.position, volumeDano1);
    }
    private void Dano2SFX()
    {
        AudioSource.PlayClipAtPoint(dano2SFX, Camera.main.transform.position, volumeDano2);
    }
    private void Dano3SFX()
    {
        AudioSource.PlayClipAtPoint(dano3SFX, Camera.main.transform.position, volumeDano3);
    }
}
