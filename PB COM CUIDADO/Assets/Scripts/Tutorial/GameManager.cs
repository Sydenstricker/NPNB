using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int pontosMaxColetaveisTut = 0;
    private int pontos;
    private GameObject player;
    [SerializeField] private GameObject playerCAV;
    private Vector2 playerInicio;
    [SerializeField] private bool isTutorial = false;

    public Text pontosTxt;
    public Text pontosTxtMenu;
    public Text pontosTxtScore;


    public DeathMenu deathMenu;
    public ScoreMenu scoremenu;
    public ScoreMenu piMenu;
    
    void Start()
    {
        if (isTutorial)
        {
            pontos = 0;
            player = GameObject.Find("PlayerTut");
            playerInicio = player.transform.position;
        }
    }

    public void AddPontos(int valor) {
        pontos += valor;
        pontosTxt.text = "" + pontos;
        pontosTxtMenu.text =  pontos + ("/") + pontosMaxColetaveisTut;
        pontosTxtScore.text =  pontos + ("/") + pontosMaxColetaveisTut;
    }

    public void RestartGame() {
        player.SetActive(false);
        deathMenu.gameObject.SetActive(true);
        
    }
    public void HighScoreTut()
    {
        player.SetActive(false);
        scoremenu.gameObject.SetActive(true);
    }
    public void HighScoreCav()
    {
        scoremenu.gameObject.SetActive(true);
        playerCAV.SetActive(false);
    }
    public void PIMenuCav()
    {
        piMenu.gameObject.SetActive(true);
        playerCAV.SetActive(false);
    }

    public void Restart() {
        deathMenu.gameObject.SetActive(false);
        scoremenu.gameObject.SetActive(false);
        player.transform.position = playerInicio;
        player.SetActive(true);
        pontos = 0;
        pontosTxt.text = "" + pontos;
        pontosTxtMenu.text = "High score: " + pontos;
    }
    
}
