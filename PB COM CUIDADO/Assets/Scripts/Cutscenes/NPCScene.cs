using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScene : MonoBehaviour
{
    public TriggerDialogue trigger;
   
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            trigger.StartDialogue();
            Destroy(gameObject.GetComponent<Collider2D>());                      

        }
            
    }   
           
}
       
