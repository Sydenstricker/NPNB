using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PIDisplayCav : MonoBehaviour
{
    Text piText;
    PlayerCav playercav;
    void Start()
    {
        piText = GetComponent<Text>();
        playercav = FindObjectOfType<PlayerCav>();
    }

    void Update()
    {
        //piText.text = player.GetPI().ToString();
        piText.text = playercav.pontosIDcoletados.ToString();
    }
}