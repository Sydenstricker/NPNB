using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativadorDoLoboAndar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponentInChildren<MorcegoEsquerda>().AtivaAndarLobo();
            //FindObjectOfType<MorcegoEsquerda>().AtivaAndarLobo();
            Debug.Log("corre cachorro");
        }
        
    }
}
