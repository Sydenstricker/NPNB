using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovCav : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject glitchMorteCav;
    public GameObject glitchScoreCav;

    void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
    public void AtivaGlitchMorte()
    {
        glitchMorteCav.SetActive(true);
    }
    public void DesativaGlitchMorte()
    {
        glitchMorteCav.SetActive(false);
    }
    public void AtivaGlitchScore()
    {
        glitchScoreCav.SetActive(true);
    }
    public void DesativaGlitchScore()
    {
        glitchScoreCav.SetActive(false);
    }
}
