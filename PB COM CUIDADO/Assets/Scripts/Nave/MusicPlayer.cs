using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
   
    void Awake()
    {
        //Singleton pra musica nao ficar resetando quando muda scene
        SetUpSingleton();        
    }
    
    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
   /* private void Update()
    {
        if (GetComponent<Boss>().bossMorreu == true)
        {
            DestruirMusicaPorFavor();
        }
    }
    public void DestruirMusicaPorFavor()
    {        
        Destroy(gameObject);
    }
   */
}
