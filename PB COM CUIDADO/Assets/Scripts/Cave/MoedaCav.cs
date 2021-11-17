using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoedaCav : MonoBehaviour
{
    [SerializeField] AudioClip coletaSFX;
    [SerializeField] [Range(0, 1)] float volumeColeta = 0.75f;
    [SerializeField] int scoreValue = 10;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("PlayerColl") ) {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(coletaSFX, Camera.main.transform.position, volumeColeta);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            
        }
        
    }
}
