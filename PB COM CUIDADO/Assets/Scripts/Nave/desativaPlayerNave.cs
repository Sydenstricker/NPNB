using UnityEngine;

public class desativaPlayerNave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Player>().PlayerVenceuFicaImortal();
        Debug.Log("NAVE IMORTAL");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
