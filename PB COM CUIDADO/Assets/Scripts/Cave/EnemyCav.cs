using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCav : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rigidBody2D;
    //[SerializeField] GameObject spriteTomouDano; spawna sprite quando toma dano
       
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  
    }
                
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            animator.SetTrigger("VoaMorcego");
            //transform.position = new Vector3(-0.01f,-0.05f,0);
            //PerseguePlayer();
        }
        if (other.gameObject.layer == 15)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.down);
            //Quaternion AngleAxis(float angle, Vector3 axis);
            //transform.rotation = Quaternion.Euler(0, -180f, 0);
            Debug.Log("flipa lobo wuf wuf");
        }
        if (other.gameObject.layer == 16)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.zero);
            //Quaternion AngleAxis(float angle, Vector3 axis);
            //transform.rotation = Quaternion.Euler(0, -180f, 0);
            Debug.Log("desflipa lobo wuf wuf");
        }
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 15)
        {
            //transform.rotation = Quaternion.AngleAxis(180, Vector3.zero);
            //Quaternion AngleAxis(float angle, Vector3 axis);
            //transform.rotation = Quaternion.Euler(0, -180f, 0);
            Debug.Log("gira lobo wuf wuf");
        }
    }
    private void MovimentaMorcegoDiagonal()
    {
        transform.position = new Vector2(-0.1f, -0.1f);
        Debug.Log("Morcego persegue Player loucamente");        
    }

    private void PerseguePlayer()
    {
        transform.position = FindObjectOfType<PlayerCav>().gameObject.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, transform.position, Time.deltaTime);
    }

}
