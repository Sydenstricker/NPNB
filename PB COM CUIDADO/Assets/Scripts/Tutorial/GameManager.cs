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

    private float contadorTempoTUT = 0;
    
    void Start()
    {
        if (isTutorial)
        {
            pontos = 0;
            player = GameObject.Find("PlayerTut");
            playerInicio = player.transform.position;
            contadorTempoTUT = 0;
        }
    }
   
    public void AddPontos(int valor) {
        pontos += valor;
        pontosTxt.text = "" + pontos;
        pontosTxtMenu.text =  pontos + ("/") + pontosMaxColetaveisTut;
        pontosTxtScore.text = pontos + ("/") + pontosMaxColetaveisTut;   

    }

    public void RestartGame() 
    {
        player.SetActive(false);
        Cursor.visible = true;
        deathMenu.gameObject.SetActive(true);        
    }
    public void HighScoreTut()
    {
        Cursor.visible = true;
        scoremenu.gameObject.SetActive(true);
        AdicionaScoreNoPlayerDataTUT();
        AdicionaTempoNoPlayerDataTUT();
        player.SetActive(false);
        FindObjectOfType<PlayerData>().NaoDestroiPlayerData();
    }
    public void HighScoreCav()
    {
        Cursor.visible = true;
        scoremenu.gameObject.SetActive(true);
        AdicionaScoreNoPlayerDataCAV();
        AdicionaPINoPlayerDataCAV();
        AdicionaTempoNoPlayerDataCAV();
        AdicionaVIDANoPlayerDataCAV();
        playerCAV.SetActive(false);

    }
    public void HighScoreNave()
    {
        Cursor.visible = true;
        AdicionaScoreNoPlayerDataNAVE();
        AdicionaPINoPlayerDataNAVE();
        AdicionaTempoNoPlayerDataNAVE();
        AdicionaVIDANoPlayerDataNAVE();        
    }
    public void PIMenuCav()
    {
        Cursor.visible = true;
        piMenu.gameObject.SetActive(true);
        playerCAV.SetActive(false);
    }

    public void Restart() 
    {
        Cursor.visible = true;
        deathMenu.gameObject.SetActive(false);
        scoremenu.gameObject.SetActive(false);
        player.transform.position = playerInicio;
        player.SetActive(true);
        pontos = 0;
        pontosTxt.text = "" + pontos;
        pontosTxtMenu.text = "High score: " + pontos;
    }
    public void AdicionaScoreNoPlayerDataTUT()
    {
        FindObjectOfType<PlayerData>().pontosObtidosTUT = pontos;
    }
    public void AdicionaScoreNoPlayerDataCAV()
    {
        FindObjectOfType<PlayerData>().pontosObtidosCAV = FindObjectOfType<GameSession>().GetScore();
    }
    public void AdicionaScoreNoPlayerDataNAVE()
    {
        FindObjectOfType<PlayerData>().pontosObtidosNAVE = FindObjectOfType<GameSession>().GetScore();
    }
    public void AdicionaPINoPlayerDataCAV()
    {
        FindObjectOfType<PlayerData>().PIcoletadosCAV = FindObjectOfType<PlayerCav>().GetPI();
    }
    public void AdicionaPINoPlayerDataNAVE()
    {
        FindObjectOfType<PlayerData>().PIcoletadosNAVE = FindObjectOfType<Player>().GetPI();
    }
    public void AdicionaVIDANoPlayerDataCAV()
    {
        FindObjectOfType<PlayerData>().vidaCAV = FindObjectOfType<PlayerCav>().GetHealth();
    }
    public void AdicionaVIDANoPlayerDataNAVE()
    {
        FindObjectOfType<PlayerData>().vidaNAVE = FindObjectOfType<Player>().GetHealth();
    }
    public void AdicionaTempoNoPlayerDataTUT()
    {
        FindObjectOfType<PlayerData>().tempoPorFaseTUT = FindObjectOfType<PlayerController>().TempoDuracaoTUT();
    }
    public void AdicionaTempoNoPlayerDataCAV()
    {
        FindObjectOfType<PlayerData>().tempoPorFaseCAV = FindObjectOfType<PlayerCav>().TempoDuracaoCAV();
    }
    public void AdicionaTempoNoPlayerDataNAVE()
    {
        FindObjectOfType<PlayerData>().tempoPorFaseNAVE = FindObjectOfType<Player>().GetTempo();
    }

}
