using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBossNaveUI : MonoBehaviour
{
    public GameObject vidaBossUI;
    

    public void AtivaVidaBoss()
    {
        vidaBossUI.SetActive(true);
    }

    public int PegaVidaBoss(int health)
    {
        FindObjectOfType<Boss>().AtualizaVidaBoss(health);
        return health;
    }

}
