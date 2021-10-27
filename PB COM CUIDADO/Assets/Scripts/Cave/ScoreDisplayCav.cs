using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro; usa texto normal mesmo

public class ScoreDisplayCav : MonoBehaviour
{
    Text scoreText;
    GameSession gameSession;
    private void Awake()
    {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
}
