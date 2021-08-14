using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerIntro : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip startgame;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayAudio(string nome)
    {
        if (nome == "startgame")
            audio.PlayOneShot(startgame);

    }
}
