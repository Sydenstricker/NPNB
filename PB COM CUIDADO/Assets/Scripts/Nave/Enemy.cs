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
    [SerializeField] bool isNaveTutorial = false;
    private bool inimigoSoltaPI = false;

    [SerializeField] GameObject explosaoAnimacao;
    [SerializeField] GameObject PIPrefab;
    [SerializeField] GameObject HPPrefab;
    private Animator animator;
    //[SerializeField] GameObject spriteTomouDano; spawna sprite quando toma dano
    private bool estouComMedoWhileLoop = false;

    [Header("Inimigo Atirando")]
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject morteVFX;
    [SerializeField] float durationOfExplosion =1f;
    [SerializeField] int pontosPorInimigo;
    private bool papaiBossMorreuEstouTristeVouMeExplodir = false;
    private bool semMeteoroPlz = true;
    private PolygonCollider2D polygonCollider2D;

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
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        animator = GetComponent<Animator>();
        CreateLaserParent();
        CreatePIParent();
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }
    void Update()
    {
        CountDownAndShoot();
        if (!FindObjectOfType<Boss>())
        {
            return;
        }
        papaiBossMorreuEstouTristeVouMeExplodir = FindObjectOfType<Boss>().VamosSeExplodir();
        if (papaiBossMorreuEstouTristeVouMeExplodir && semMeteoroPlz)
        {
            shotCounter = 9999999999f;
            StartCoroutine(MinionsSeExplodemDelay(3f));
        }
    }
    private IEnumerator MinionsSeExplodemDelay(float tempoSomeMinions)
    {
        animator.SetTrigger("Morreu");
        polygonCollider2D.enabled = false;
        semMeteoroPlz = false;
        yield return new WaitForSeconds(tempoSomeMinions);
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
        if(isNaveTutorial) { FindObjectOfType<StationTutorialSaiDeCena>().TiraPlataformaCenaTutorial(); }
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
        inimigosSoltamPI = Random.Range(chanceMinSoltarPID, chanceMaxSoltarPID);
        if (inimigosSoltamPI <= 5 && estouComMedoWhileLoop == false)
        {
            GameObject PI = Instantiate(PIPrefab, transform.position, Quaternion.identity) as GameObject;
            PI.transform.parent = pontosIDParent.transform;
        }
              
    }
    private void SpawnRandomHP()
    {
        inimigosSoltamHP = Random.Range(chanceMinSoltarHP, chanceMaxSoltarHP);
        if ((inimigosSoltamHP <= 5) && (inimigoSoltaPI = false))
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
    public void DesativaDropPIBossPuto()
    {
        estouComMedoWhileLoop = true;
    }

    public void PapaiBossMorreuEstouTristeVouMeExplodir()
    {
        papaiBossMorreuEstouTristeVouMeExplodir = true;
    }
    public void MinionsBossNaoSpawnaPI()
    {
        inimigoSoltaPI = true;
    }
}
