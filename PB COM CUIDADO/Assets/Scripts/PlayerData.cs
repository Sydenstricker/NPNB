using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<PlayerData>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
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
