using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computadores : MonoBehaviour
{
    public AudioClip computadores;
    [SerializeField] [Range(0, 1)] float volumeComputadores = 0.75f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(computadores, Camera.main.transform.position, volumeComputadores);
        }
    }    
}
