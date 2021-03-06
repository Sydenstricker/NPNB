using UnityEngine;

public class MorcegoEsquerda : MonoBehaviour
{
    [SerializeField] private float sedeDeSangue = 4f;
    [SerializeField] private bool pegaPlayer = false;
    [SerializeField] bool isLobo = false;
    [SerializeField] bool isMorcego = false;
    private Animator animator;
    private Rigidbody2D lobo;
    void Start()
    {
        animator = GetComponent<Animator>();
        lobo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pegaPlayer == true)
        {
            AndaLobo();
        }
    }

    private void AndaLobo()
    {
        lobo.velocity = new Vector2(sedeDeSangue, 0);
        if(isMorcego)
        {
            return;
        }
        if(isLobo)
        {
            FindObjectOfType<SoundManager>().LoboRosna();
            isLobo = false;
        }
    }
    public void AtivaAndarLobo()
    {
        pegaPlayer = true;
    }
}

