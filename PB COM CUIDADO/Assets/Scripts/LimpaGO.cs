using UnityEngine;

public class LimpaGO : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.CompareTag("Plataforma Tutorial"))
        { FindObjectOfType<EnemySpawner>().NaveTutorialMorreuStartarEnemyWave(); }
    }
}
