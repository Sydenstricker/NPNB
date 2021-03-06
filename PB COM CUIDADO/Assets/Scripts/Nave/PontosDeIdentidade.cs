using UnityEngine;

public class PontosDeIdentidade : MonoBehaviour
{

    [SerializeField] AudioClip coletaSFX;
    [SerializeField] [Range(0, 1)] float volumeColeta = 0.75f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource.PlayClipAtPoint(coletaSFX, Camera.main.transform.position, volumeColeta);
        FindObjectOfType<Player>().PontosdeID();
        Destroy(gameObject);
    }
}
