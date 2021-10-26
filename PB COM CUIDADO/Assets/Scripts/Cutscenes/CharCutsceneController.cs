using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharCutsceneController : MonoBehaviour
{
    [Header("SFX Cinematic")]
    [SerializeField] AudioClip andaSFX;
    [SerializeField] [Range(0, 1)] float volumeAnda = 0.75f;
    [SerializeField] AudioClip correSFX;
    [SerializeField] [Range(0, 1)] float volumeCorre = 0.75f;

    [Header("Outros Configs")]
    [SerializeField] float velocity = 10f;
    private Rigidbody2D body;
    private Animator pinkyAnimator;
    private float contaTempo = 0f;
    private bool estaAndando = false;
    [SerializeField] float limiteAndar = 0f;
    [SerializeField] float delayBlueCorrer = 0f;
    private bool isCorrendoSFX = true;
    private bool isAndandoSFX = true;
       


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        pinkyAnimator = GetComponent<Animator>();     
    }       

    // Update is called once per frame
    void Update()
    {        
        if (estaAndando == true)
        {
            contaTempo++;
            pinkyAnimator.SetBool("andar", true);
            Debug.Log(contaTempo);
        }
        if (contaTempo >= limiteAndar)
        {
            pinkyAnimator.SetBool("andar", false);
            ParaPinkTutorial();
            contaTempo = 0;
        }
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
        //pinkyAnimator.SetBool("andando", false);
    }
    private void AndaPinkTutorial()
    {
        body.velocity = new Vector2(velocity, body.velocity.y);
        pinkyAnimator.SetFloat("Velocidade", body.velocity.x);
        if(isAndandoSFX)
        {
            AudioSource.PlayClipAtPoint(andaSFX, Camera.main.transform.position, volumeAnda);
            isAndandoSFX = false;
            isCorrendoSFX = true;
        }
    }

    //Animações
    private void OnTriggerEnter2D(Collider2D collision)
    {
        pinkyAnimator.SetTrigger("EntraFase");
        Debug.Log("Corre menina");
    }    
    public void ExclamacaoPinky()
    {
        pinkyAnimator.SetTrigger("exclamacao");
        Debug.Log("animacao exclamacao");        
    }    
     
    public void OlhaAtrasPinky()
    {
        pinkyAnimator.SetTrigger("olhaTras");
        Debug.Log("animacao olha para tras");
    }
    public void OlhaAtrasFixoONPinky()
    {
        pinkyAnimator.SetBool("isOlhandoTras", true);
        Debug.Log("animacao olha para tras");
    }
    public void OlhaAtrasFixoOFFPinky()
    {
        pinkyAnimator.SetBool("isOlhandoTras", false);
        Debug.Log("animacao olha para tras");
    }
    public void TrofeuPinky()
    {
        pinkyAnimator.SetTrigger("Trofeu");
        Debug.Log("animacao trofeu");
    }
    public void CheckPinky()
    {
        pinkyAnimator.SetTrigger("check");
        Debug.Log("animacao check");
    }
    public void PuloDuroPinky()
    {
        pinkyAnimator.SetTrigger("puloDuro");
        Debug.Log("animacao pulo Duro");        
    }
    public void CorrePink()
    {
        pinkyAnimator.SetTrigger("correr");
        if(isCorrendoSFX)
        {
            AudioSource.PlayClipAtPoint(correSFX, Camera.main.transform.position, volumeCorre);
            isCorrendoSFX = false;
            isAndandoSFX = true;
        }
    }
}

