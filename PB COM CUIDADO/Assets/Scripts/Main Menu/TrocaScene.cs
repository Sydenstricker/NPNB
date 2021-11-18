using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaScene : MonoBehaviour
{

    private float tempoMudaScene = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Change_Scene", tempoMudaScene);
    }
    void Change_Scene()
    {
        SceneManager.LoadScene("Intro Logo 2");
    }
}
