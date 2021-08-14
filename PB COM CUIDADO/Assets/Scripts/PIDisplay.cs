using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PIDisplay : MonoBehaviour
{
    Text piText;
    Player player;
    void Start()
    {
        piText = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }
        
    void Update()
    {
        //piText.text = player.GetPI().ToString();
        piText.text = player.pontosIDcoletados.ToString();
    }
}
