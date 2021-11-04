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
    [SerializeField] float delayUIFilipeFicouAssustadoVei = 2.2f;
    private Animator animator;

    [Header("Sons")]
    [SerializeField] AudioClip explosoesfreneticasSFX;
    [SerializeField] [Range(0, 1)] float volumeExplosoes = 0.75f;
    [SerializeField] AudioClip BossPutoMusic;
    [SerializeField] [Range(0, 1)] float volumeBossPutoMusic = 0.75f;
    [SerializeField] [Range(0, 1)] float volumeTiroCanhao = 0.75f;
    [SerializeField] float tempoIntroBoss = 2f;

    [Header("Explosoes Configs")]
    
    public GameObject explosoes;

    [Header("Canhoes Puto")]
    public GameObject canhoesPuto;   


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
        StartCoroutine(DelayBarraVidaBossUI());
    }
    private IEnumerator DelayBarraVidaBossUI()
    {
        yield return new WaitForSeconds(delayUIFilipeFicouAssustadoVei); 
        FindObjectOfType<VidaBossNaveUI>().AtivaVidaBoss();
        AjustaUIBossComBOSSInstanciado();
        PegaVidaCoracao();
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
        FindObjectOfType<EnemySpawner>().InvocaReforcosBOSS();
        FindObjectOfType<BossPathing>().BossIsPuto();
        StartCoroutine(AtivaCanhoesPutosEncimaBossAtirandoPewPewPew(0.1f));
    }
    private void BossMorreu()
    {
        StartCoroutine(DesativaCanhoesPutosEncimaBossAtirandoPewPewPew(0.1f));
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

        foreach (Transform child in canhoesPuto.transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(intervaloAcionamentoCannons);
        }
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(DesativaCanhoesPutosEncimaBossAtirandoPewPewPew(0));
        yield return new WaitForSeconds(10);
        StartCoroutine(AtivaCanhoesPutosEncimaBossAtirandoPewPewPew(intervaloAcionamentoCannons));

    }
    private IEnumerator DesativaCanhoesPutosEncimaBossAtirandoPewPewPew(float intervaloAcionamentoCannons)
    {
        foreach (Transform child in canhoesPuto.transform)
        {
            child.gameObject.SetActive(false);
            yield return new WaitForSeconds(intervaloAcionamentoCannons);
        }
    }


    private IEnumerator ExplosoesFreneticas(float intervaloExplosoes)
    {
        foreach (Transform child in explosoes.transform)
        {
            child.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(explosoesfreneticasSFX, Camera.main.transform.position, volumeExplosoes);
            yield return new WaitForSeconds(intervaloExplosoes);
        }

    }
    public int AtualizaVidaBoss(int health)
    {
        return health;
    }

}
