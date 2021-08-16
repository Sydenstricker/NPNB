using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCav : MonoBehaviour
{
    [Header("Inimigo Configs")]
    [SerializeField] int chanceMaxSoltarPID = 100;
    [SerializeField] int chanceMinSoltarPID = 1;
    [SerializeField] int inimigosSoltamPI;
        
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
