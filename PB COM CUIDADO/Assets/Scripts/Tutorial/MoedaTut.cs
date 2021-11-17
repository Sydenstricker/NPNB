using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoedaTut : MonoBehaviour
{
    [SerializeField] AudioClip coletaSFX;
    [SerializeField] [Range(0, 1)] float volumeColeta = 0.75f;
    [SerializeField] int scoreValue = 10;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("PlayerColl"))
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(coletaSFX, Camera.main.transform.position, volumeColeta);
            gameManager.AddPontos(10);
            //FindObjectOfType<GameSession>().AddToScore(scoreValue);

        }

    }
}
