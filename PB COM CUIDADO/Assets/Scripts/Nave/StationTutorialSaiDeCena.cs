using UnityEngine;

public class StationTutorialSaiDeCena : MonoBehaviour
{
    [SerializeField] private float velocidadeSaideCena = 0f;
    private float velocidadeX = 0.1f;
    private bool podeAndarPlataformaTut = false;


    // Update is called once per frame
    void FixedUpdate()
    {
        velocidadeX += velocidadeSaideCena;
        if(podeAndarPlataformaTut == false) { NaoTiraPlataformaCenaTutorial(); }
        if (podeAndarPlataformaTut) { AndaPlataforma(); };
    }
    public void TiraPlataformaCenaTutorial()
    {
        velocidadeSaideCena = 10.5f * (Time.deltaTime);
        podeAndarPlataformaTut = true;
    }
    public void NaoTiraPlataformaCenaTutorial()
    {
        velocidadeSaideCena = 0f;
        podeAndarPlataformaTut = false;
    }

    private void AndaPlataforma()
    {
        transform.position = new Vector2(-1.16f - velocidadeX, transform.position.y);
    }

}
