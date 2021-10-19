using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [Header("Boss Configs")]
    
    [SerializeField] int health = 10000;
    [SerializeField] int vidaBossFicaPuto = 5000;
    [SerializeField] int scoreValue = 150;    
    private Animator animator;    

    [Header("Sons")]
    [SerializeField] AudioClip explosoesfreneticasSFX;
    [SerializeField] [Range(0, 1)] float volumeExplosoes = 0.75f;
    [SerializeField] AudioClip introSFX;
    [SerializeField] [Range(0, 1)] float volumeIntro = 0.75f;
    [SerializeField] float tempoIntroBoss = 2f;

    [Header("Explosoes Configs")]
    [SerializeField] GameObject explosoes;
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

    [Header("NAO MEXER Boss UI ")]
    public Slider bossSlider;
    public HealthBar healthBarBoss;
    public int currentHealthBoss;  
    
      

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        AtivaUIBoss();
        AjustaUIBossComBOSSInstanciado();
        PegaVidaCoracao();
        SomChefePutissimo();
    }

    private void AjustaUIBossComBOSSInstanciado()
    {
        bossSlider = GameObject.Find("BossSlider").GetComponent<Slider>();
        bossSlider.maxValue = health;
        bossSlider.minValue = 0;
    }

    public void PegaVidaCoracao()
    {
        FindObjectOfType<VidaBossNaveUI>().EstaHealthBar(healthBarBoss);
        currentHealthBoss = health;
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
        currentHealthBoss = health;
        healthBarBoss.SetHealth(currentHealthBoss);
        bossSlider.value = currentHealthBoss;

        if (health == vidaBossFicaPuto)
        {
            BossFicouPutoInvocaMinionsParaAjudar();           
        }
        if (health <= 0)
        {
            BossMorreu();            
        }               
    }

    private void BossFicouPutoInvocaMinionsParaAjudar()
    {
        FindObjectOfType<EnemySpawner>().InvocaReforçosBOSS();
        FindObjectOfType<BossPathing>().BossIsPuto();
    }
       private void BossMorreu()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        animator.SetTrigger("Morreu");
       
        GetComponentInChildren<Cannon>().CannonStopShooting();
        StartCoroutine(ExplosoesFreneticas(0.3f));
               
        FindObjectOfType<Level>().LoadCinematicaFinal();       
    }
    

    private IEnumerator ExplosoesFreneticas(float intervaloExplosoes)
    {
        Explosao1.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao2.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao3.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao4.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao5.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao5.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao6.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao7.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao8.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao9.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao10.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao11.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao12.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao13.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao14.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao15.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao16.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao17.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao18.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao19.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao20.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
        Explosao21.SetActive(true);
        AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
        yield return new WaitForSeconds(intervaloExplosoes);
    }
    public int AtualizaVidaBoss(int health)
    {
        return health;
    }

}
