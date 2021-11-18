using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    int piScore = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    public int GetScore()
    {
        return score;
    }
    public int GetPiScore()
    {
        return piScore;
    }
    public void AddToPIScore(int scoreValue)
    {
        //piScore = FindObjectOfType<PlayerCav>().GetPI();
        piScore += scoreValue;
    }
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
