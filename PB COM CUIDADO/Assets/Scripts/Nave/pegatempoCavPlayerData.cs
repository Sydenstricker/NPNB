using UnityEngine;
using UnityEngine.UI;
public class pegatempoCavPlayerData : MonoBehaviour
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
        scoreText.text = FindObjectOfType<PlayerData>().tempoPorFaseCAV.ToString("F2");
    }
}
