using UnityEngine;

public class PortalTriggerPlayer : MonoBehaviour
{
    private Animator animator;
    [SerializeField] bool isTutorial = false;
    [SerializeField] bool isNaveFim = false;
    [SerializeField] bool estamosSemTempo = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("AbrePortal");
            if (isTutorial)
            {
                FindObjectOfType<SoundManager>().TocaPortalFecha();
                return;
            }   
            if(isNaveFim)
            {
                animator.SetTrigger("NaveFim");
            }
            if(isNaveFim && estamosSemTempo)
            {
                FindObjectOfType<SoundManager>().TocaPortalFecha();
            }
        }
    }
    public void VelhoAtivaPortal()
    {
        animator.SetTrigger("AbrePortal");
    }
}
