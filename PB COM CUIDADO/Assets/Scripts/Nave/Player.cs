using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player Config")]
    [SerializeField] float velCimaBaixo = 10f;
    [SerializeField] float velEsqDir = 10f;
    [SerializeField] float limiteTela = 1f;
    [SerializeField] int health = 200;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
   
    [Header("Player Audio")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float volumeMorte = 0.75f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;
    [SerializeField] AudioClip danoBossSFX;
    [SerializeField] [Range(0, 1)] float volumeDanoBoss = 0.75f;


    [Header("Projectile Shoot")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed = 1f;
    [SerializeField] float projectileFirePeriod = 0.1f;

    Coroutine firingCoroutine;

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
        Fire();        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Tiro Boss"))
        {
            TomouTiroBoss();
            Debug.Log("tomou tiro boss");
        }
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return;}
        TomarDano(damageDealer);
            
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
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion,durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, volumeMorte);
        FindObjectOfType<Level>().LoadGameOver();
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetPI()
    {
        return pontosIDcoletados;
    }
    private void Fire()
    {
        //Fire1
        if (Input.GetButtonDown("Jump"))
        {
           firingCoroutine = StartCoroutine(FireHoldingFire());
        }
        if (Input.GetButtonUp("Jump"))
        {
           StopCoroutine(firingCoroutine);
        }
    }   
    private void Move()
    {
       
        var deltaY = Input.GetAxis("Vertical") * (Time.deltaTime) *velCimaBaixo;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY,(yMin),yMax);

        var deltaX = Input.GetAxis("Horizontal") * (Time.deltaTime) * velEsqDir;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
    

        //jogador anda para cima/baixo
        transform.position = new Vector2(newXPos , transform.position.y);

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
    IEnumerator FireHoldingFire()
    {
        while (true)
        {
            //dar ofset do tiro pra direita
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(laserSpeed, 0);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(projectileFirePeriod);
        }
    }
    public void PontosdeID()
    {
        pontosIDcoletados++;
    }
    private void TomouTiroBoss()
    {
        AudioSource.PlayClipAtPoint(danoBossSFX, Camera.main.transform.position, volumeDanoBoss);
        StartCoroutine(TremePlayer(0.6f,0.1f));
    }
    IEnumerator TremePlayer(float duration, float magnetude)
    {
        Vector2 originalPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = originalPos.x +(Random.Range(-1f, 1f) * magnetude);
            float y = originalPos.y + (Random.Range(-1f, 1f) * magnetude);

            transform.position = new Vector2(x, y);

            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.position = originalPos;
        Debug.Log("efeito de tremer ao tomar tiro funcionou");
    }
    
}
