using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorcegoEsquerda : MonoBehaviour
{
    [SerializeField] private float sedeDeSangue = 4f;
    [SerializeField] private bool pegaPlayer = false;
    private Animator animator;
    private Rigidbody2D lobo;
    void Start()
    {
        animator = GetComponent<Animator>();
        lobo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pegaPlayer == true)
        {
            AndaLobo();
        }
       
    }

    private void AndaLobo()
    {
        lobo.velocity = new Vector2(sedeDeSangue, 0);
        Debug.Log("lobo esta sedento por sangue");
    }
    public void AtivaAndarLobo()
    {
        pegaPlayer = true;
    }
}

