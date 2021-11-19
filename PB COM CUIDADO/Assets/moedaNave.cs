using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moedaNave : MonoBehaviour
{
    [SerializeField] AudioClip coletaSFX;
    [SerializeField] [Range(0, 1)] float volumeColeta = 0.75f;
    [SerializeField] int scoreValue = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 8)        
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(coletaSFX, Camera.main.transform.position, volumeColeta);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            print("pegou waffle");
        }
    }
}
