using UnityEngine;

public class PortalNaveFim : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AtivaPortalNaveFim()
    {
        animator.SetTrigger("NaveFim");
        FindObjectOfType<SoundManager>().TocaPortalAbre();
        FindObjectOfType<SoundManager>().PortalExplosion();
    }
}
