using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //private bool destruirGO = false;
    //private int ativarDestruirGO = 0;
    void Awake()
    {
        //Singleton pra musica nao ficar resetando quando muda scene
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void BossSpawnouParaMusicaFase()
    {
        Destroy(gameObject);
    }
    public void DesbugaMusicaDuplicada()
    {
        Destroy(gameObject);
    }
    /*private void Update()
    {
        ativarDestruirGO = FindObjectsOfType<Boss>().Length;
        destruirGO = GetComponent<Boss>().bossMorreu;
        if (ativarDestruirGO > 1)
        {
            Destroy(gameObject);
        }
        if (destruirGO == true)
        {
            DestruirMusicaPorFavor();
        }
    }
    public void DestruirMusicaPorFavor()
    {        
        Destroy(gameObject);
    }
    */

}
