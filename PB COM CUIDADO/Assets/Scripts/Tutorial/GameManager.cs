using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int pontos;
    private GameObject player;
    private Vector2 playerInicio;

    public Text pontosTxt;
    public Text pontosTxtMenu;

    public DeathMenu deathMenu;
    
    void Start()
    {
        pontos = 0;
        player = GameObject.Find("Player");
        //playerInicio = player.transform.position;
    }

    public void AddPontos(int valor) {
        pontos += valor;
        pontosTxt.text = "Pontos: " + pontos;
        pontosTxtMenu.text = "Pontos: " + pontos;
    }

    public void RestartGame() {
        player.SetActive(false);
        deathMenu.gameObject.SetActive(true);        
    }

    public void Restart() {
        deathMenu.gameObject.SetActive(false);
        player.transform.position = playerInicio;
        player.SetActive(true);
        pontos = 0;
        pontosTxt.text = "Pontos: " + pontos;
        pontosTxtMenu.text = "Pontos: " + pontos;
    }
}
