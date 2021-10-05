using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
   private Animator animator;
    private Rigidbody2D rigidBody2D;
    private bool start = false;
    [SerializeField] private float velMorcegoStalker = 6f;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8){
            animator.SetTrigger("VoaMorcego");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            start = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(start){
            var targetPosition = FindObjectOfType<PlayerCav>().gameObject.transform.position;
            var movementThisFrame = velMorcegoStalker * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
        }
    }
}
