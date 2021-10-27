using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAndaDialogo : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator blueAnimator;
    private float contaTempo = 0f;
    private bool naoSeMova = false;
    private bool andaPELOAMORDEDEUS = false;
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

    void Update()
    {        
        if(estaAndando)
        {
            contaTempo++;
            blueAnimator.SetBool("andar", true);
            AndaBlueESQ();
        }
        if(contaTempo >= limiteAndar)
        {
            blueAnimator.SetBool("andar", false);
            ParaBlue();
            andaPELOAMORDEDEUS = false;
            contaTempo = 0;
        }
        if (DialogueCutsceneManager.isActive == true)
        {
            if(andaPELOAMORDEDEUS)
            {
                AndaBlue();
            }
            else
            {
                ParaBlue();
            }
           
        }
        if (DialogueCutsceneManager.isActive == false && naoSeMova == false )
        {
            AndaBlue();
        }
    }

    public void NAOSEMOVEBlue()
    {
        naoSeMova = true;
    }
    public void ParaBlue()
    {
        body.velocity = new Vector2(0, 0);
        blueAnimator.SetBool("andar", false);        
    } 
    public void AndaBlue()
    {
        body.velocity = new Vector2(velocidade, body.velocity.y);
        blueAnimator.SetBool("andar", true);
    }
    public void AndaBlueESQ()
    {
        body.velocity = new Vector2(velocidade, 0);
        blueAnimator.SetBool("andar", true);
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
        naoSeMova = true;
        estaAndando = false;
        yield return new WaitForSeconds(delayBlueCorrer);
        transform.rotation = Quaternion.AngleAxis(180, Vector3.down);
        body.velocity = new Vector2(-velocidade, 0);
        blueAnimator.SetBool("correr", true);        
    }

    public void CorreNaveFinal()
    {
        body.velocity = new Vector2(-5, 0);
        estaAndando = true;
    }
   public void OlhaTrasBlue()
    {
        blueAnimator.SetBool("isOlhandoTras", true);
    }
    public void OlhaFrenteBlue()
    {
        blueAnimator.SetBool("isOlhandoTras", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            ParaBlue();
            andaPELOAMORDEDEUS = false;
        }
    }    
    
    public void ANDAPELOAMORDEDEUS ()
    {
        andaPELOAMORDEDEUS = true;
    }
}
