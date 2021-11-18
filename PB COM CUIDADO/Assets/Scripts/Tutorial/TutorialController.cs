using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public TextAsset file;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<DialogManager>().StartDialog(file);
            Destroy(gameObject.GetComponent<Collider2D>());

        }
    }

}
