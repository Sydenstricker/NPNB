using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipadorLobo : MonoBehaviour
{
    private int flipa = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //transform.rotation = ()
        transform.rotation = Quaternion.Euler(0,180f,0);
        Debug.Log("gira lobo wuf wuf");
    }
   

}
