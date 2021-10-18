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
    [SerializeField] AudioClip danoShot1;
    [SerializeField] [Range(0, 1)] float volumeShot1 = 0.75f;
    [SerializeField] AudioClip danoShot2;
    [SerializeField] [Range(0, 1)] float volumeShot2 = 0.75f;
    [SerializeField] AudioClip danoShot3;
    [SerializeField] [Range(0, 1)] float volumeShot3 = 0.75f;
    [SerializeField] AudioClip danoShot4;
    [SerializeField] [Range(0, 1)] float volumeShot4 = 0.75f;
    [SerializeField] AudioClip danoShot5;
    [SerializeField] [Range(0, 1)] float volumeShot5 = 0.75f;
    [SerializeField] AudioClip danoShot6;
    [SerializeField] [Range(0, 1)] float volumeShot6 = 0.75f;


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
        if (other.gameObject.CompareTag("shot1"))     { TomouTiroShot1();  }
        if (other.gameObject.CompareTag("shot2"))     { TomouTiroShot2();  }
        if (other.gameObject.CompareTag("shot3"))     { TomouTiroShot3();  }
        if (other.gameObject.CompareTag("shot4"))     { TomouTiroShot4();  }
        if (other.gameObject.CompareTag("shot5"))     { TomouTiroShot5();  }
        if (other.gameObject.CompareTag("shot6"))     { TomouTiroShot6();  }
        
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
    private void TomouTiroShot1()
    {
        AudioSource.PlayClipAtPoint(danoShot1, Camera.main.transform.position, volumeShot1);        
    }
    private void TomouTiroShot2()
    {
        AudioSource.PlayClipAtPoint(danoShot2, Camera.main.transform.position, volumeShot2);
    }
    private void TomouTiroShot3()
    {
        AudioSource.PlayClipAtPoint(danoShot3, Camera.main.transform.position, volumeShot3);
    }
    private void TomouTiroShot4()
    {
        AudioSource.PlayClipAtPoint(danoShot4, Camera.main.transform.position, volumeShot4);
    }
    private void TomouTiroShot5()
    {
        AudioSource.PlayClipAtPoint(danoShot5, Camera.main.transform.position, volumeShot5);
    }
    private void TomouTiroShot6()
    {
        AudioSource.PlayClipAtPoint(danoShot6, Camera.main.transform.position, volumeShot6);
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
