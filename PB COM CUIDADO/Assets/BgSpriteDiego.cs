using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpriteDiego : MonoBehaviour
{    
    private bool teste2 = false;
    public float tamanhoSprite = 0f;
    
    void Start()
    {
        tamanhoSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void OnBecameVisible()
    {
        teste2 = true;        
    }
    
    void Update()
    {        
        if (teste2)
        {                     
            if (GetComponent<Renderer>().isVisible == false)
            {                
                transform.position = new Vector2(transform.position.x + (tamanhoSprite*2), transform.position.y);
                teste2 = false;
            }
        }         
    }
}

