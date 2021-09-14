using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip moeda;
    public AudioClip pulo;
    public AudioClip startgame;
    public AudioClip quitgame;
    public AudioClip puloduplo;
    public AudioClip obstaculocolision;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayAudio(string nome){
        if(nome=="moeda")
            audio.PlayOneShot(moeda);
        else if(nome=="pulo")
            audio.PlayOneShot(pulo);
        else if(nome== "startgame")
            audio.PlayOneShot(startgame); 
        else if (nome == "quitgame")
            audio.PlayOneShot(quitgame);
        else if (nome == "puloduplo")
            audio.PlayOneShot(puloduplo);
        else if (nome == "obstaculocolision")
            audio.PlayOneShot(obstaculocolision);
    }
}
