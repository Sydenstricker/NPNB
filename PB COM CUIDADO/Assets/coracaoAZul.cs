using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coracaoAZul : MonoBehaviour
{
    private Animator corAzul;
    private int vidaCoracapSpriteAzul = 200;
    void Start()
    {
        corAzul = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PegaVidaNave();

        if (vidaCoracapSpriteAzul >= 200)
        {
            corAzul.SetFloat("vida", 200);
        }
        if (vidaCoracapSpriteAzul <= 120 && vidaCoracapSpriteAzul >= 40)
        {
            corAzul.SetFloat("vida", 120);
        }
        if (vidaCoracapSpriteAzul < 41 && vidaCoracapSpriteAzul >= 1)
        {
            corAzul.SetFloat("vida", 40);
        }
        if (vidaCoracapSpriteAzul < 1)
        {
            corAzul.SetFloat("vida", 0);
        }


    }

    private void PegaVidaNave()
    {
        vidaCoracapSpriteAzul = FindObjectOfType<Player>().GetHealth();
    }
}
