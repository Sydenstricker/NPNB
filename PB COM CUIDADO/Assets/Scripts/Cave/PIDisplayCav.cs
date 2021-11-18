using UnityEngine;
using UnityEngine.UI;

public class PIDisplayCav : MonoBehaviour
{
    Text piText;

    GameSession gameSession;
    PlayerCav playercav;
    void Start()
    {
        piText = GetComponent<Text>();
        playercav = FindObjectOfType<PlayerCav>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        //piText.text = playercav.GetPI().ToString();
        //piText.text = player.GetPI().ToString();
        //piText.text = playercav.pontosIDcoletados.ToString();
        piText.text = gameSession.GetPiScore().ToString();
    }
}