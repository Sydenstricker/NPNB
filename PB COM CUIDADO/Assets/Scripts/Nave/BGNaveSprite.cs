using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGNaveSprite : MonoBehaviour
{
   
    private float dist2 = 10f;
    [SerializeField] private float  parallaxEffect = 0f;
    private float contaTempo = 0f;
    
    void Update()
    {
        contaTempo++;
        //dist = -contaTempo * Time.deltaTime * parallaxEffect;
        dist2 = 10f * -parallaxEffect * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + dist2, transform.position.y, transform.position.z);
    }
}
