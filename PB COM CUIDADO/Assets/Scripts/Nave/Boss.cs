using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Inimigo Configs")]
    
    [SerializeField] int health = 100;
    [SerializeField] int scoreValue = 150;
    private Animator animator;
    [SerializeField] GameObject explosoes;
    [SerializeField] float vidaBossSegundaParte = 100f;
    public GameObject Explosao1;
    public GameObject Explosao2;
    public GameObject Explosao3;
    public GameObject Explosao4;
    public GameObject Explosao5;
    public GameObject Explosao6;
    public GameObject Explosao7;
    public GameObject Explosao8;
    public GameObject Explosao9;
    public GameObject Explosao10;
    public GameObject Explosao11;
    public GameObject Explosao12;
    public GameObject Explosao13;
    public GameObject Explosao14;
    public GameObject Explosao15;
    public GameObject Explosao16;
    public GameObject Explosao17;
    public GameObject Explosao18;
    public GameObject Explosao19;
    public GameObject Explosao20;
    public GameObject Explosao21;
    public HealthBar healthBarBoss;
    public int currentHealth;

    //public List<GameObject> explosoesMorte;
    //[SerializeField] GameObject[] explosoesMorte;
    //public GameObject[] listaExplosoesBoss;
    //private GameObject explosoesChild;
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
        AtivaUIBoss();
        PegaVidaCoracao();
        SomChefePutissimo();       
    }
    private void PegaVidaCoracao()
    {
        currentHealth = health;
        healthBarBoss.SetMaxHealth(health);
    }

    private void SomChefePutissimo()
    {
        StartCoroutine((IEnumerator)WaitAndLoad());        
    }
    private void AtivaUIBoss()
    {
        FindObjectOfType<VidaBossNaveUI>().AtivaVidaBoss();
        
    }
   
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(tempoIntroBoss);
        AudioSource.PlayClipAtPoint(introSFX, Camera.main.transform.position, volumeIntro);
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
        currentHealth = health;
        healthBarBoss.SetHealth(currentHealth);
        
        if (health <= 0)
        {
            BossMorreu();            
        }               
    }

       private void BossMorreu()
    {
        //bossMorreu = true;
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        animator.SetTrigger("Morreu");
        ExplosoesFreneticas(0.3f);
       
        GetComponentInChildren<Cannon>().CannonStopShooting();
        StartCoroutine(ExplosoesFreneticas(0.3f));
        //Instantiate(GetComponentInChildren <[GameObject] >);

        //Destroy(gameObject);
        //GameObject explosion = Instantiate(morteVFX, transform.position, transform.rotation);
        //Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, volumeMorte);
        FindObjectOfType<Level>().LoadCinematicaFinal();       
    }
    

    private IEnumerator ExplosoesFreneticas(float intervaloExplosoes)
    {
        Explosao1.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao2.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao3.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao4.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao5.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao5.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao6.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao7.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao8.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao9.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao10.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao11.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao12.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao13.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao14.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao15.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao16.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao17.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao18.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao19.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao20.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao21.SetActive(true);
        yield return new WaitForSeconds(intervaloExplosoes);
    }
    public int AtualizaVidaBoss(int health)
    {
        return health;
    }

}
