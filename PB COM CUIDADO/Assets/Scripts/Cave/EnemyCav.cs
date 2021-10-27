using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCav : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody2D;
    [SerializeField] private bool isMorcegoStalker = false;
    [SerializeField] private float velMorcegoStalker = 10f;    
       
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  
    }
                
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((isMorcegoStalker == true) && (other.gameObject.layer == 8))
        {
            animator.SetTrigger("VoaMorcego");
            MovimentaMorcegoDiagonal();
        }
        if (other.gameObject.layer == 15)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.down);           
        }
        if (other.gameObject.layer == 16)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.down);
        }
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 15)
        {
            return;
        }
    }
    private void MovimentaMorcegoDiagonal()
    {
        var targetPosition = FindObjectOfType<PlayerCav>().gameObject.transform.position;
        var movementThisFrame = velMorcegoStalker * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
     
    }

    private void PerseguePlayer()
    {
        transform.position = FindObjectOfType<PlayerCav>().gameObject.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, transform.position, Time.deltaTime);
    }

}
