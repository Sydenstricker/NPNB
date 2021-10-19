using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("TUT")]
    public int pontosObtidosTUT;
    public float tempoPorFaseTUT;

    [Header("CAV")]
    public int PIcoletadosCAV;
    public int pontosObtidosCAV;
    public int vidaCAV;
    public float tempoPorFaseCAV;

    [Header("NAVE")]
    public int PIcoletadosNAVE;
    public int pontosObtidosNAVE;
    public int vidaNAVE;
    public float tempoPorFaseNAVE;
    
    public void NaoDestroiPlayerData()
    {
        DontDestroyOnLoad(this);
    }
}
