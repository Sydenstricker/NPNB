using UnityEngine;

public class ativadorDoLoboAndar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponentInChildren<MorcegoEsquerda>().AtivaAndarLobo();
        }
    }
}
