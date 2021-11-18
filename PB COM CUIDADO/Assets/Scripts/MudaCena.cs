using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaCena : MonoBehaviour
{
    private float changeScene = 8f;

    void Start()
    {
        Invoke("Change_Scene", changeScene);
    }

    void Change_Scene()
    {
        SceneManager.LoadScene("ThanksForPlaying");
    }
}
