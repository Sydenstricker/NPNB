using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool GameisPaused = true;

    public GameObject pauseMenuUI;
    [SerializeField] bool isNave = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        Cursor.visible = false;
        if(isNave)
        {
            FindObjectOfType<StationTutorialSaiDeCena>().TiraPlataformaCenaTutorial();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        Cursor.visible = true;
        if(isNave)
        {
            FindObjectOfType<StationTutorialSaiDeCena>().NaoTiraPlataformaCenaTutorial();
        }
    }
}
