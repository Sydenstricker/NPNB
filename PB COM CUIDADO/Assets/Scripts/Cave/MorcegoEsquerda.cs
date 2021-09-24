using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorcegoEsquerda : MonoBehaviour
{
    [SerializeField] private float sedeDeSangue = 4f;
    private Animator animator;
    private Rigidbody2D boneco;
    void Start()
    {
        animator = GetComponent<Animator>();
        boneco = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        boneco.velocity = new Vector2(-sedeDeSangue, boneco.velocity.y);        
    }
}

