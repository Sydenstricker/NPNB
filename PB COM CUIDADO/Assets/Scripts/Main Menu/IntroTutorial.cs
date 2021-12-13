using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTutorial : MonoBehaviour
{
    [SerializeField] bool isEN = false;
    public int Tutorial;
    private float tempoMudaScene = 90f;

    // Start is called before the first frame update
    void Start()
    {
        if(isEN == false)
        {
            Invoke("Change_Scene", tempoMudaScene);
        }
        else
        {
            Invoke("Change_SceneEN", tempoMudaScene);
        }
    }
    void Change_Scene()
    {
        SceneManager.LoadScene("Tutorial");
    }
    void Change_SceneEN()
    {
        SceneManager.LoadScene("TutorialEN");
    }
}


