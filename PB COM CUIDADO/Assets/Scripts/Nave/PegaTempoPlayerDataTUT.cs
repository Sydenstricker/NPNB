using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegaTempoPlayerDataTUT : MonoBehaviour
{
    Text scoreText;
    GameSession gameSession;
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = FindObjectOfType<PlayerData>().tempoPorFaseTUT.ToString("F2");
    }
}
