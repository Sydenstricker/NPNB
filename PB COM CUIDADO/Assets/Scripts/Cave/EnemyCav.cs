using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCav : MonoBehaviour
{
            
    //[SerializeField] GameObject spriteTomouDano; spawna sprite quando toma dano
       
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }        
    }
      
        
}
