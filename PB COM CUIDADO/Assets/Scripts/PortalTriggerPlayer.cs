using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTriggerPlayer : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("AbrePortal");
            animator.SetTrigger("NaveFim");
        }
    }
    public void VelhoAtivaPortal()
    {
        animator.SetTrigger("AbrePortal");
    }
}
