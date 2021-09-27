using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAndaDialogo : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator blueAnimator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        blueAnimator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void AndaBlueESQ()
    {
        body.velocity = new Vector2(-5, body.velocity.y);
    }
    private void ParaBlue()
    {
        body.velocity = new Vector2(0, body.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            ParaBlue();
        }
    }  

}
