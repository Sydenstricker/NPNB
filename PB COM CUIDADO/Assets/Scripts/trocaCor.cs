using UnityEngine;
using UnityEngine.UI;

public class trocaCor : MonoBehaviour
{
    private bool bossPutoBarraDeVidaVermelha = false;
    public Color myColor;
    public float rFloat = 217f;
    public float gFloat = 178f;
    public float bFloat = 60f;
    //public float aFloat = 255f;
    //public Renderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //aFloat = 255f;
        //myColor = new Color(rFloat, gFloat, bFloat);
        //gameObject.GetComponent<Image>().color = myColor;
        //gameObject.GetComponent<Image>().color =new Color(rFloat, gFloat, bFloat);
        //myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossPutoBarraDeVidaVermelha)
        {
            rFloat = 1f;
            myColor = new Color(rFloat, gFloat, bFloat);
            //myRenderer.material.color = myColor;
            gameObject.GetComponent<Image>().color = myColor;
        }
    }
    public void BossPutoVidaVermelha()
    {
        bossPutoBarraDeVidaVermelha = true;
    }
}
