using UnityEngine;

public class MoetaTuto : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "playerCollider")
        {
            Destroy(gameObject);
            gameManager.AddPontos(10);
        }

    }
}