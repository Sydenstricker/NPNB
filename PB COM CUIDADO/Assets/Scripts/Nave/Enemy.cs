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
    [SerializeField] int inimigosSoltamPI;

    [SerializeField] GameObject PIPrefab;
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

    GameObject enemyLaserParent;
    const string ENEMY_LASER_NAME = "EnemyLaser";
    void Start()
    {        
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
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
    }

    private void SpawnRandomPI()
    {
        inimigosSoltamPI = Random.Range(chanceMinSoltarPID,chanceMaxSoltarPID);
        if (inimigosSoltamPI >= 10)
        {
            GameObject PI = Instantiate(PIPrefab, transform.position, Quaternion.identity) as GameObject;
        }
        //else return;
    }
}
