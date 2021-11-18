using UnityEngine;

public class BolaPretaEntra : MonoBehaviour
{
    public Animator bolaPreta;
    void Start()
    {
        bolaPreta = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AtivaBolaPreta()
    {
        bolaPreta.SetTrigger("BolaEntra");
    }
}
