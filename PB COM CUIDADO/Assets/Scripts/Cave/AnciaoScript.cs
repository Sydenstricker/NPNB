using UnityEngine;

public class AnciaoScript : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnciaoProcurando()
    {
        animator.SetTrigger("procurando");
    }
    public void AnciaoAtivaPortal()
    {
        animator.SetTrigger("trocaLado");
        FindObjectOfType<SoundManager>().TocaPortalAbre();
    }
}
