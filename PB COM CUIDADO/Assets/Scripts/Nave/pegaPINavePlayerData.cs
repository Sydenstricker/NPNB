using UnityEngine;
using UnityEngine.UI;

public class pegaPINavePlayerData : MonoBehaviour
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
        scoreText.text = FindObjectOfType<PlayerData>().PIcoletadosNAVE.ToString();
    }
}
