using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAndaDialogo : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator blueAnimator;
    private float contaTempo = 0f;
    [SerializeField] float velocidade = 2.5f;
    [SerializeField] private bool estaAndando = false;
    [SerializeField] float limiteAndar = 0f;
    [SerializeField] float delayBlueCorrer = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        blueAnimator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {        
        if(estaAndando)
        {
            contaTempo++;
            blueAnimator.SetBool("andar", true);
            Debug.Log(contaTempo);
        }
        if(contaTempo >= limiteAndar)
        {
            blueAnimator.SetBool("andar", false);
            ParaBlue();
            contaTempo = 0;
        }
        if (DialogueCutsceneManager.isActive == true)
        {
            ParaBlue();
        }
        if (DialogueCutsceneManager.isActive == false)
        {
            AndaBlue();
        }
    }
    private void ParaBlue()
    {
        body.velocity = new Vector2(0, 0);
        blueAnimator.SetFloat("Velocidade", 0);
        //pinkyAnimator.SetBool("andando", false);
    }
    public void AndaBlue()
    {
        body.velocity = new Vector2(velocidade, body.velocity.y);
        blueAnimator.SetFloat("Velocidade", body.velocity.x);
    }
    public void AndaBlueESQ()
    {
        body.velocity = new Vector2(-5, 0);
        estaAndando = true;
    }
    public void CorreDireita()
    {
        StartCoroutine((IEnumerator) CorreBlueDir());        
    }
    public void PulaBlue()
    {
        blueAnimator.SetTrigger("Pulo");
    }
    private IEnumerator CorreBlueDir()
    {
        yield return new WaitForSeconds(delayBlueCorrer);
        transform.rotation = Quaternion.AngleAxis(180, Vector3.down);
        body.velocity = new Vector2(3, 0);
        blueAnimator.SetBool("correr", true);
        Debug.Log("CORRE BLUE MEU FILHO");
    }

    public void CorreNaveFinal()
    {
        body.velocity = new Vector2(-5, 0);
        estaAndando = true;
    }
    //private void ParaBlue()
    //{
       // body.velocity = new Vector2(0, 0);
     //   estaAndando = false;
   // }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            ParaBlue();
        }
    }  
    
}
