using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCutsceneController : MonoBehaviour
{

    [SerializeField] float velocity = 10f;
    private Rigidbody2D body;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();     
    }       

    // Update is called once per frame
    void Update()
    {
        if (DialogueCutsceneManager.isActive == true)
        {
            ParaPinkTutorial();
        }
        if (DialogueCutsceneManager.isActive == false)
        {
            AndaPinkTutorial();
        }
       

    }
    
    private void ParaPinkTutorial()
    {
        body.velocity = new Vector2(0, 0);
        animator.SetFloat("Velocidade", 0);
    }
    private void AndaPinkTutorial()
    {
        body.velocity = new Vector2(velocity, body.velocity.y);
        animator.SetFloat("Velocidade", body.velocity.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("EntraFase");
        Debug.Log("Corre menina");
    }
}
