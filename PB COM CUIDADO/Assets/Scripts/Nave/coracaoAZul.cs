using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class coracaoAZul : MonoBehaviour
{
    private Animator corAzul;
    private int vidaCoracapSpriteAzul = 200;
    private bool playerMorreu = false;
    void Start()
    {
        corAzul = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PegaVidaNave();

        if (vidaCoracapSpriteAzul >= 500)
        {
            corAzul.SetInteger("vida",4);
        }
        if ((vidaCoracapSpriteAzul <= 320) && (vidaCoracapSpriteAzul >= 240))
        {
            corAzul.SetInteger("vida", 3);
        }
        if ((vidaCoracapSpriteAzul < 241) && (vidaCoracapSpriteAzul > 1))
        {
            corAzul.SetInteger("vida", 2);
        }
        if ((vidaCoracapSpriteAzul < 1) || (playerMorreu))
        {
            corAzul.SetInteger("vida", 1);
        }
    }
    private void PegaVidaNave()
    {
        if (FindObjectOfType<Player>() == null )
        {
            playerMorreu = true;
            return;
        }
        vidaCoracapSpriteAzul = FindObjectOfType<Player>().GetHealth();
    }
    
}

