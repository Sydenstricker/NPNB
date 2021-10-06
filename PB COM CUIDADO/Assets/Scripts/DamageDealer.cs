using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private Animator tiroBoss;
    
    [SerializeField] int damage = 100;

    private void Start()
    {
        tiroBoss = GetComponent<Animator>();
    }
    public int GetDamage()
    {
        return damage;
    }
    public void Hit()
    {
        if (gameObject.CompareTag("Tiro Boss"))
        {
            tiroBoss.SetTrigger("acertou");
            Debug.Log("tiro do Boss acertou");
        }
        else
            Destroy(gameObject);
    }
    public void PedraCaiFeliz()
    {
        return;
    }
}
