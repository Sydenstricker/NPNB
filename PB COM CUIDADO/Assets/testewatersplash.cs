using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testewatersplash : MonoBehaviour
{
    [SerializeField] GameObject splashVFX;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            splashVFX.gameObject.SetActive(true);
            Debug.Log("splash teste");
        }
    }
}
