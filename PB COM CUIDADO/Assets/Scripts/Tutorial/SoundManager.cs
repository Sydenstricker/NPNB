using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip moeda;
    [SerializeField] [Range(0, 1)] float volumeMoeda = 0.75f;
    public AudioClip pulo;
    [SerializeField] [Range(0, 1)] float volumePulo= 0.75f;
    public AudioClip startgame;
    [SerializeField] [Range(0, 1)] float volumeStartGame = 0.75f;
    public AudioClip quitgame;
    [SerializeField] [Range(0, 1)] float volumeQuitGame = 0.75f;
    public AudioClip puloduplo;
    [SerializeField] [Range(0, 1)] float volumePuloDuplo = 0.75f;
    public AudioClip portalEntra;
    [SerializeField] [Range(0, 1)] float volumePortalEntra = 0.75f;
    public AudioClip portalSai;
    [SerializeField] [Range(0, 1)] float volumePortalSai = 0.75f;
    public AudioClip deathMenu;
    [SerializeField] [Range(0, 1)] float volumeDeathMenu = 0.75f;

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

    public void PlayAudio(string nome){
        if (nome == "moeda")
            AudioSource.PlayClipAtPoint(moeda, Camera.main.transform.position, volumeMoeda);
        //audio.PlayOneShot(moeda);
        else if (nome == "pulo")
            AudioSource.PlayClipAtPoint(pulo, Camera.main.transform.position, volumePulo);
        //audio.PlayOneShot(pulo);
        else if (nome == "StartGame")
             {
                 AudioSource.PlayClipAtPoint(startgame, Camera.main.transform.position, volumeStartGame);
                 Debug.Log("tocou botao start");
             }
        //audio.PlayOneShot(startgame);
        else if (nome == "quitgame")
            AudioSource.PlayClipAtPoint(quitgame, Camera.main.transform.position, volumeQuitGame);
        //audio.PlayOneShot(quitgame);
        else if (nome == "puloduplo")
            AudioSource.PlayClipAtPoint(puloduplo, Camera.main.transform.position, volumePuloDuplo);
        //audio.PlayOneShot(puloduplo);
        else if (nome == "portalentra")
            AudioSource.PlayClipAtPoint(portalEntra, Camera.main.transform.position, volumePortalEntra);
        //audio.PlayOneShot(portalEntra);
        else if (nome =="portalfecha")
            AudioSource.PlayClipAtPoint(portalSai, Camera.main.transform.position, volumePortalSai);
        //audio.PlayOneShot(portalSai);
        else if (nome =="deathMenu")
            AudioSource.PlayClipAtPoint(deathMenu, Camera.main.transform.position, volumeDeathMenu);
    }
    public void TocaPortalFecha()
    {
        audio.PlayOneShot(portalSai);
    }
    public void TocaDeathMenu()
    {
        AudioSource.PlayClipAtPoint(deathMenu, Camera.main.transform.position, volumeDeathMenu);
    }
}
