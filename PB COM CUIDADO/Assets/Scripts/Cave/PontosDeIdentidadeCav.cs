using UnityEngine;

public class PontosDeIdentidadeCav : MonoBehaviour
{
    [SerializeField] AudioClip coletaSFX;
    [SerializeField] [Range(0, 1)] float volumeColeta = 0.75f;
    private const int scoreValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerColl"))
        {
            AudioSource.PlayClipAtPoint(coletaSFX, Camera.main.transform.position, volumeColeta);
            FindObjectOfType<PlayerCav>().PontosdeID();
            FindObjectOfType<GameSession>().AddToPIScore(scoreValue);
            Destroy(gameObject);
        }
    }

}