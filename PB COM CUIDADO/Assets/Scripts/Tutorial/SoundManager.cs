using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audio;
    //public AudioClip moeda;
    //[SerializeField] [Range(0, 1)] float volumeMoeda = 0.75f;
    //public AudioClip pulo;
    //[SerializeField] [Range(0, 1)] float volumePulo = 0.75f;
    public AudioClip startgame;
    [SerializeField] [Range(0, 1)] float volumeStartGame = 0.75f;
    public AudioClip quitgame;
    [SerializeField] [Range(0, 1)] float volumeQuitGame = 0.75f;
    //public AudioClip puloduplo;
    //[SerializeField] [Range(0, 1)] float volumePuloDuplo = 0.75f;
    public AudioClip portalEntra;
    [SerializeField] [Range(0, 1)] float volumePortalEntra = 0.75f;
    public AudioClip portalSai;
    [SerializeField] [Range(0, 1)] float volumePortalSai = 0.75f;
    public AudioClip portalExplosion;
    [SerializeField] [Range(0, 1)] float volumePExplosion = 0.75f;
    public AudioClip deathMenu;
    [SerializeField] [Range(0, 1)] float volumeDeathMenu = 0.75f;
    public AudioClip loboRosna;
    [SerializeField] [Range(0, 1)] float volumeLoboRosna = 0.75f;
    public AudioClip loboMorde;
    [SerializeField] [Range(0, 1)] float volumeLoboMorde = 0.75f;
    public AudioClip morcegoRosna;
    [SerializeField, Range(0, 1)] float volumeMorcegoRosna = 0.75f;
    public AudioClip stalkerSound;
    [SerializeField, Range(0, 1)] float volumeStalkerSound = 0.75f;
    public AudioClip splash;
    [SerializeField, Range(0, 1)] float volumeSplash = 0.75f;
    public AudioClip morcegoMorde;
    public AudioClip HPNaveSFX;
    [SerializeField][Range(0, 1)] float volumeHPNave = 0.75f;
    public AudioClip naveBomberSFX;
    public AudioClip naveSeExplode;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<SoundManager>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayAudio(string nome)
    {
        //if (nome == "moeda")
            //AudioSource.PlayClipAtPoint(moeda, Camera.main.transform.position, volumeMoeda);
        //audio.PlayOneShot(moeda);
        //else if (nome == "pulo")
            //AudioSource.PlayClipAtPoint(pulo, Camera.main.transform.position, volumePulo);
        //audio.PlayOneShot(pulo);
        if (nome == "StartGame")
        {
            AudioSource.PlayClipAtPoint(startgame, Camera.main.transform.position, volumeStartGame); // nao passa para outra scene
            Debug.Log("tocou botao start");
            audio.PlayOneShot(startgame); // passa para outra scene
        }
        else if (nome == "quitgame")
            audio.PlayOneShot(quitgame);
        //else if (nome == "puloduplo")
        //AudioSource.PlayClipAtPoint(puloduplo, Camera.main.transform.position, volumePuloDuplo);
        //audio.PlayOneShot(puloduplo);
        else if (nome == "portalentra")
            AudioSource.PlayClipAtPoint(portalEntra, Camera.main.transform.position, volumePortalEntra);
            //audio.PlayOneShot(portalEntra);
        else if (nome == "portalfecha")
            AudioSource.PlayClipAtPoint(portalSai, Camera.main.transform.position, volumePortalSai);
        //audio.PlayOneShot(portalSai);
        else if (nome == "deathMenu")
            AudioSource.PlayClipAtPoint(deathMenu, Camera.main.transform.position, volumeDeathMenu);
    }
    public void TocaPortalFecha()
    {
        
        audio.PlayOneShot(portalSai, volumePortalSai);
    }
    public void TocaDeathMenu()
    {
        AudioSource.PlayClipAtPoint(deathMenu, Camera.main.transform.position, volumeDeathMenu);
    }
    public void TocaPortalAbre()
    {
        audio.PlayOneShot(portalEntra, volumePortalEntra);
    }
    public void PortalExplosion()
    {
        audio.PlayOneShot(portalExplosion, volumePExplosion);
    }
    public void LoboRosna()
    {
        audio.PlayOneShot(loboRosna, volumeLoboRosna);
    }
    public void LoboMorde()
    {
        audio.PlayOneShot(loboMorde, volumeLoboMorde);
    }
    public void MorcegoRosna()
    {
        audio.PlayOneShot(morcegoRosna, volumeMorcegoRosna);
    }
    public void StalkerSound()
    {
        audio.PlayOneShot(stalkerSound, volumeStalkerSound);
    }
    public void Splash()
    {
        audio.PlayOneShot(splash, volumeSplash);
    }
    public void MorcegoMorde()
    {
        audio.PlayOneShot(morcegoMorde);
    }   
    public void HPNave()
    {
        audio.PlayOneShot(HPNaveSFX);
    }
    public void NaveBomberSFX()
    {
        audio.PlayOneShot(naveBomberSFX);
        Debug.Log("nave bomber acertoiu");
    }
    public void NaveSeExplode()
    {
        AudioSource.PlayClipAtPoint(naveSeExplode, Camera.main.transform.position, volumeDeathMenu);
        //audio.PlayOneShot(naveSeExplode);
    }
}
