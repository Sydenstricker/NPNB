using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaCena : MonoBehaviour
{
    private float changeScene = 8f;
    [SerializeField] bool isEN = false;

    void Start()
    {
        if (isEN == false)
        {
            Invoke("Change_Scene", changeScene);
        }
        else
        {
            Invoke("Change_SceneEN", changeScene);
        }
    }

    void Change_Scene()
    {
        SceneManager.LoadScene("ThanksForPlaying");
    }
    void Change_SceneEN()
    {
        SceneManager.LoadScene("ThanksForPlayingEN");
    }
}
