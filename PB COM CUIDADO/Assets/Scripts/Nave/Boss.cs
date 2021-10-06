using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Inimigo Configs")]
    [SerializeField] float health = 100f;
    [SerializeField] int scoreValue = 150;
    private Animator animator;
    //public bool bossMorreu = false;
    

    [Header("Inimigo Atirando")]
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject morteVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] int pontosPorInimigo;
        
    [Header("Sons")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float volumeMorte = 0.75f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;
    [SerializeField] AudioClip introSFX;
    [SerializeField] [Range(0, 1)] float volumeIntro = 0.75f;
    [SerializeField] float tempoIntroBoss = 2f;
      

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        SomChefePutissimo();
    }
        
    private void SomChefePutissimo()
    {
        StartCoroutine((IEnumerator)WaitAndLoad());        
    }
   
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(tempoIntroBoss);
        AudioSource.PlayClipAtPoint(introSFX, Camera.main.transform.position, volumeIntro);
    }

    void Update()
    {
          
    }
    
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        TomarDano(damageDealer);
        animator.SetTrigger("Ai");        
    }

    private void TomarDano(DamageDealer damageDealer)
    {
        if (damageDealer == null) { return; }
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            BossMorreu();            
        }               
    }

       private void BossMorreu()
    {
        //bossMorreu = true;
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(morteVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, volumeMorte);
        FindObjectOfType<Level>().LoadCinematicaFinal();       
    }       
}
