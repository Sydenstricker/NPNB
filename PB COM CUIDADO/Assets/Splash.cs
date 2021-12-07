using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<SoundManager>().Splash();            
            //GetComponentInChildren<splash>(splashAgua);
            FindObjectOfType<PlayerCav>().AtivaAguaSplash(); 
        }
    }
}
