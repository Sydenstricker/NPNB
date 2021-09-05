using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipadorLobo : MonoBehaviour
{
    private const float Y =-180f;

    //Rigidbody2D myRigidBody;
    private void Start()
    {
        //myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //transform.localScale = new Vector2(-1, 1f);
        
        transform.rotation = Quaternion.Euler(0, Y, 0);
        Debug.Log("gira lobo wuf wuf");
    }
    


}
