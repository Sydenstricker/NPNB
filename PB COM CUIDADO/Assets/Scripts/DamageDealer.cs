using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private Animator tiroBoss;
    [SerializeField] bool ehParaDesaparecerQuandoMorre = false;
    [SerializeField] int damage = 100;
    [SerializeField] bool isLobo = false;
    [SerializeField] bool isMorcego = false;
    [SerializeField] bool isHP = false;
    [SerializeField] bool isMataPlayer = false;
    [SerializeField] bool isNave = false;

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
        if (gameObject.CompareTag("Tiro Boss")) { tiroBoss.SetTrigger("acertou"); return; }
        if (gameObject.CompareTag("shot1")) { tiroBoss.SetTrigger("acertou"); return; }
        if (gameObject.CompareTag("shot2")) { tiroBoss.SetTrigger("acertou"); return; }
        if (gameObject.CompareTag("shot3")) { tiroBoss.SetTrigger("acertou"); return; }
        if (gameObject.CompareTag("shot4")) { tiroBoss.SetTrigger("acertou"); return; }
        if (gameObject.CompareTag("shot5")) { tiroBoss.SetTrigger("acertou"); return; }
        if (gameObject.CompareTag("shot6"))
        { 
            tiroBoss.SetTrigger("acertou");
            FindObjectOfType<SoundManager>().NaveBomberSFX();
            return;
        }
        if (gameObject.CompareTag("Nave"))
            {
                //FindObjectOfType<Enemy>().PlayerSeExplodiuComigo();
                tiroBoss.SetTrigger("Morreu");
                return;
            }
        if (ehParaDesaparecerQuandoMorre) 
        { 
            if (isMorcego)
            {
                FindObjectOfType<SoundManager>().MorcegoMorde();
                Destroy(GetComponent<BoxCollider2D>());
            }
            if(isLobo)   
            { 
                FindObjectOfType<SoundManager>().LoboMorde();
                //Destroy(GetComponent<BoxCollider2D>());
                
            }
            if(isHP)    
            { 
                FindObjectOfType<SoundManager>().HPNave();
                Destroy(gameObject);

            }
            if(isMataPlayer)
            {
                Destroy(this);
            }
            else    
            {    
                return; 
            }

            
           
        }
       
    }
    public void PedraCaiFeliz()
    {
        return;
    }
}
