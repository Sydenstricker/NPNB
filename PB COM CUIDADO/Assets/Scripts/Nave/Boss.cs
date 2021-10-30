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
    [SerializeField] AudioClip BossPutoMusic;
    [SerializeField] [Range(0, 1)] float volumeBossPutoMusic = 0.75f;
    [SerializeField] float tempoIntroBoss = 2f;

    [Header("Explosoes Configs")]
    //[SerializeField] GameObject explosoes;
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

    [Header("Canhoes Puto Forgive me Diego")]
    [SerializeField] public GameObject canhaoPuto1;
    [SerializeField] public GameObject canhaoPuto2;
    [SerializeField] public GameObject canhaoPuto3;
    [SerializeField] public GameObject canhaoPuto4;
    [SerializeField] public GameObject canhaoPuto5;
    [SerializeField] public GameObject canhaoPuto6;
    [SerializeField] public GameObject canhaoPuto7;
    [SerializeField] public GameObject canhaoPuto8;


    [Header("NAO MEXER Boss UI ")]
    public Slider bossSlider;
    public HealthBar healthBarBoss;
    public int currentHealthBoss;
    PolygonCollider2D polygonCollider2D;
    
      

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
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
        FindObjectOfType<MusicPlayer>().BossSpawnouParaMusicaFase();
        AudioSource.PlayClipAtPoint(BossPutoMusic, Camera.main.transform.position, volumeBossPutoMusic);
        yield return new WaitForSeconds(tempoIntroBoss);
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
        StartCoroutine(AtivaCanhoesPutosEncimaBossAtirandoPewPewPew(0.1f));
    }
       private void BossMorreu()
    {
        StartCoroutine(DesativaCanhoesPutosEncimaBossAtirandoPewPewPew(0));
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        animator.SetTrigger("Morreu");
        FindObjectOfType<GameManager>().HighScoreNave();       
        GetComponentInChildren<Cannon>().CannonStopShooting();
        polygonCollider2D.enabled = false;
        StartCoroutine(ExplosoesFreneticas(0.3f));               
        FindObjectOfType<Level>().LoadCinematicaFinal();       
    }

    private IEnumerator AtivaCanhoesPutosEncimaBossAtirandoPewPewPew(float intervaloAcionamentoCannons)
    {
        
        canhaoPuto1.SetActive(true);
        yield return new WaitForSeconds(intervaloAcionamentoCannons);
        canhaoPuto2.SetActive(true);
        yield return new WaitForSeconds(intervaloAcionamentoCannons);
        canhaoPuto3.SetActive(true);
        yield return new WaitForSeconds(intervaloAcionamentoCannons);
        canhaoPuto4.SetActive(true);
        yield return new WaitForSeconds(intervaloAcionamentoCannons);
        canhaoPuto5.SetActive(true);
        yield return new WaitForSeconds(intervaloAcionamentoCannons);
        canhaoPuto6.SetActive(true);
        yield return new WaitForSeconds(intervaloAcionamentoCannons);
        canhaoPuto7.SetActive(true);
        yield return new WaitForSeconds(intervaloAcionamentoCannons);
        canhaoPuto8.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(DesativaCanhoesPutosEncimaBossAtirandoPewPewPew(0));
        yield return new WaitForSeconds(10);
        StartCoroutine(AtivaCanhoesPutosEncimaBossAtirandoPewPewPew(intervaloAcionamentoCannons));

    }
    private IEnumerator DesativaCanhoesPutosEncimaBossAtirandoPewPewPew(float intervaloAcionamentoCannons)
    {
        canhaoPuto1.SetActive(false);
        yield return new WaitForSeconds(0);
        canhaoPuto2.SetActive(false);
        yield return new WaitForSeconds(0);
        canhaoPuto3.SetActive(false);
        yield return new WaitForSeconds(0);
        canhaoPuto4.SetActive(false);
        yield return new WaitForSeconds(0);
        canhaoPuto5.SetActive(false);
        yield return new WaitForSeconds(0);
        canhaoPuto6.SetActive(false);
        yield return new WaitForSeconds(0);
        canhaoPuto7.SetActive(false);
        yield return new WaitForSeconds(0);
        canhaoPuto8.SetActive(false);
        yield return new WaitForSeconds(0);
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
