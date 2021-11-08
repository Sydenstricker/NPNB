using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationTutorialSaiDeCena : MonoBehaviour
{
    [SerializeField] private float velocidadeSaideCena = 0f;
    private float velocidadeX = 0.1f;
    private bool podeAndarPlataformaTut = false;
   

    // Update is called once per frame
    void Update()
    {
        velocidadeX += velocidadeSaideCena;
        if (podeAndarPlataformaTut) { AndaPlataforma(); }; 
    }
    public void TiraPlataformaCenaTutorial()
    {
        velocidadeSaideCena = 0.005f;
        podeAndarPlataformaTut = true;
    }

    private void AndaPlataforma()
    {
            transform.position = new Vector2(-velocidadeX, transform.position.y);        
    }

}
