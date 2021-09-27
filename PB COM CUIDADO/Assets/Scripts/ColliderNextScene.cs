using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderNextScene : MonoBehaviour
{

    //[SerializeField] float delayBolaPreta = 1f;
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
        if (other.gameObject.layer == 9)
            return;
        else
            StopAllAudio();
            StopAllCoroutines();
            //FindObjectOfType<BolaPretaEntra>().AtivaBolaPreta();
            StartCoroutine(ProxSceneCollider());
            //CACETE FOI PORRA
            //GetComponent<BolaPretaEntra>().AtivaBolaPreta();
            //GetComponent<BolaPretaEntra>().bolaPreta.SetTrigger("EntraBola");)
        
        
       
        //FindObjectOfType<BolaPretaEntra>().AtivaBolaPreta;
    }
    IEnumerator ProxSceneCollider()
    {
        yield return new WaitForSeconds(0);
        FindObjectOfType<SceneLoader>().LoadNextScene();
        //AudioSource.PlayClipAtPoint(introSFX, Camera.main.transform.position, volumeIntro);
    }
    
 }
