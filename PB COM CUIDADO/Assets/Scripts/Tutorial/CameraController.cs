using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject glitchMorte;
    public GameObject glitchScore;

    void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
    public void AtivaGlitchMorte()
    {
        glitchMorte.SetActive(true);
    }
    public void DesativaGlitchMorte()
    {
        glitchMorte.SetActive(false);
    }
    public void AtivaGlitchScore()
    {
        glitchScore.SetActive(true);
    }
    public void DesativaGlitchScore()
    {
        glitchScore.SetActive(false);
    }
}
