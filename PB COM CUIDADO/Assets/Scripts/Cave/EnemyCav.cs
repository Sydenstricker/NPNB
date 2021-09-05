using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCav : MonoBehaviour
{

    private Animator animator;
    //[SerializeField] GameObject spriteTomouDano; spawna sprite quando toma dano
       
    void Start()
    {
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
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }        
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
