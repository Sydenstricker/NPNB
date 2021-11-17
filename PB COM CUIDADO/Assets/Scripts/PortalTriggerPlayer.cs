using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTriggerPlayer : MonoBehaviour
{
    private Animator animator;
    [SerializeField] bool isTutorial = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("AbrePortal");
            if(isTutorial)
            {
                FindObjectOfType<SoundManager>().TocaPortalFecha();
                return;
            }
            animator.SetTrigger("NaveFim");
            FindObjectOfType<SoundManager>().TocaPortalFecha();
        }
    }
    public void VelhoAtivaPortal()
    {
        animator.SetTrigger("AbrePortal");
    }
}
