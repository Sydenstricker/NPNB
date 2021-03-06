using UnityEngine;


public class VidaBossNaveUI : MonoBehaviour
{
    public GameObject vidaBossUI;
    public HealthBar healthBarBoss;


    public void AtivaVidaBoss()
    {
        vidaBossUI.SetActive(true);
    }
    public void DesativaVidaBoss()
    {
        vidaBossUI.SetActive(false);
    }

    public HealthBar EstaHealthBar(HealthBar healthBarBoss)
    {
        return healthBarBoss;
    }
    public int PegaVidaBoss(int health)
    {
        FindObjectOfType<Boss>().AtualizaVidaBoss(health);
        return health;
    }

}
