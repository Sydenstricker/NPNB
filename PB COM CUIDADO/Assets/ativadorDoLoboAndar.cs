using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativadorDoLoboAndar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInChildren<MorcegoEsquerda>().AtivaAndarLobo();
        //FindObjectOfType<MorcegoEsquerda>().AtivaAndarLobo();
        Debug.Log("corre cachorro");
    }
}
