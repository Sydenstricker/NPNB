using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Inimigo Configs")]
    [SerializeField] float health = 100f;
    [SerializeField] int scoreValue = 150;
    [SerializeField] int chanceMaxSoltarPID = 100;
    [SerializeField] int chanceMinSoltarPID = 1;
    private int inimigosSoltamPI;
    private int inimigosSoltamHP;
    [SerializeField] int chanceMaxSoltarHP = 100;
    [SerializeField] int chanceMinSoltarHP = 1;
    [SerializeField] bool isNaveBomber = false;

    [SerializeField] GameObject PIPrefab;
    [SerializeField] GameObject HPPrefab;
    private Animator animator;
    //[SerializeField] GameObject spriteTomouDano; spawna sprite quando toma dano

    [Header("Inimigo Atirando")]
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject morteVFX;
    [SerializeField] float durationOfExplosion =1f;
    [SerializeField] int pontosPorInimigo;

    [Header("Sons")]   
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0,1)] float volumeMorte = 0.75f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;

    //Organizador Inspector
    GameObject laserParent;
    const string LASER_PARENT_NAME = "Laser";
   
    GameObject pontosIDParent;
    const string PI_PARENT_NAME = "Pontos de ID";


    void Start()
    {
        animator = GetComponent<Animator>();
        CreateLaserParent();
        CreatePIParent();
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }
    void Update()
    {
        CountDownAndShoot();
    }
    private void CreatePIParent()
    {
        pontosIDParent = GameObject.Find(PI_PARENT_NAME);
        if (!pontosIDParent)
        {
            pontosIDParent = new GameObject(PI_PARENT_NAME);
        }
    }       
    private void CreateLaserParent()
    {       
        laserParent = GameObject.Find(LASER_PARENT_NAME);
        if (!laserParent)
        {
            laserParent = new GameObject(LASER_PARENT_NAME);
        }
    }
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }
    private void Fire()
    {
        GameObject laser = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        laser.transform.parent = laserParent.transform;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        TomarDano(damageDealer);        
    }
    private void TomarDano(DamageDealer damageDealer)
    {
       /* GameObject laser = Instantiate(
            spriteTomouDano,
            transform.position,
            Quaternion.identity) as GameObject;
       */ //spawna sprite quando toma dano
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        PiscaDano();
        if (health <= 0)
        {
            Morreu();
        }
    }    
    private void Morreu()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(morteVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, volumeMorte);
        SpawnRandomPI();
        SpawnRandomHP();
    }
    private void SpawnRandomPI()
    {
        inimigosSoltamPI = Random.Range(chanceMinSoltarPID,chanceMaxSoltarPID);
        if (inimigosSoltamPI <= 5)
        {
            GameObject PI = Instantiate(PIPrefab, transform.position, Quaternion.identity) as GameObject;
            PI.transform.parent = pontosIDParent.transform;
        }        
    }
    private void SpawnRandomHP()
    {
        inimigosSoltamHP = Random.Range(chanceMinSoltarHP, chanceMaxSoltarHP);
        if (inimigosSoltamHP <= 5)
        {
            GameObject HP = Instantiate(HPPrefab, transform.position, Quaternion.identity) as GameObject;
            HP.transform.parent = pontosIDParent.transform;
        }
    }
    private void PiscaDano()
    {
        if(isNaveBomber)
        {
            animator.SetTrigger("Ai");
        }
        
    }

}
