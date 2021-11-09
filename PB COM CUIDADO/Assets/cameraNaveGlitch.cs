using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraNaveGlitch : MonoBehaviour
{
    public GameObject glitchMorteNave;
    public GameObject glitchScoreNave;
       
    public void AtivaGlitchMorte()
    {
        glitchMorteNave.SetActive(true);
    }
    public void DesativaGlitchMorte()
    {
        glitchMorteNave.SetActive(false);
    }
    public void AtivaGlitchScore()
    {
        glitchScoreNave.SetActive(true);
    }
    public void DesativaGlitchScore()
    {
        glitchScoreNave.SetActive(false);
    }
}

