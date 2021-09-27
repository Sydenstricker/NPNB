using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCutsceneController : MonoBehaviour
{

    [SerializeField] float velocity = 10f;
    private Rigidbody2D body;
    private Animator pinkyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        pinkyAnimator = GetComponent<Animator>();     
    }       

    // Update is called once per frame
    void Update()
    {
        //GetComponent<DialogueCutsceneManager>().ativaExclamacao);
        //FindObjectOfType<DialogueCutsceneManager>().ativaExclamacao);
        
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
        pinkyAnimator.SetFloat("Velocidade", 0);
    }
    private void AndaPinkTutorial()
    {
        body.velocity = new Vector2(velocity, body.velocity.y);
        pinkyAnimator.SetFloat("Velocidade", body.velocity.x);
    }

    //Animações
    private void OnTriggerEnter2D(Collider2D collision)
    {
        pinkyAnimator.SetTrigger("EntraFase");
        Debug.Log("Corre menina");
    }

    public void ExclamacaoTutorial()
    {
        pinkyAnimator.SetTrigger("exclamacao");
        Debug.Log("animacao exclamacao");        
    }
    public void ExclamacaoNave()
    {
        pinkyAnimator.SetTrigger("exclamacao Nave");
        Debug.Log("animacao exclamacao");
    }

    public void OlhaAtrasTutorial()
    {
        pinkyAnimator.SetTrigger("olhaTras");
        Debug.Log("animacao olha para tras");
    }
    public void TrofeuTutorial()
    {
        pinkyAnimator.SetTrigger("Trofeu");
        Debug.Log("animacao trofeu");
    }
    public void CheckTutorial()
    {
        pinkyAnimator.SetTrigger("check");
        Debug.Log("animacao check");
    }
    public void PuloDuroTutorial()
    {
        pinkyAnimator.SetTrigger("puloDuro");
        Debug.Log("animacao pulo Duro");        
    }
}

