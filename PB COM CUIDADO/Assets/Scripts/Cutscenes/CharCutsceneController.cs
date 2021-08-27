using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCutsceneController : MonoBehaviour
{

    [SerializeField] float velocity = 10f;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueCutsceneManager.isActive == true)
            return;

        body.velocity = new Vector2(velocity, body.velocity.y);
    }
}
