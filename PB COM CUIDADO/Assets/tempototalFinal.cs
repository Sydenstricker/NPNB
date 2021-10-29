using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempototalFinal : MonoBehaviour
{
    Text text;
    private float tempoTotal = 0f;
    void Start()
    {
        text = GetComponent<Text>();
        text.text = tempoTotal.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private float retornaTempoTotal()
    {
        tempoTotal = Time.realtimeSinceStartup;
        return tempoTotal;
    }
}
