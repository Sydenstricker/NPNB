using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderNextScene : MonoBehaviour
{
    //Stop all sounds
    private AudioSource[] allAudioSources;

    private void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        StopAllAudio();
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }          
 }
