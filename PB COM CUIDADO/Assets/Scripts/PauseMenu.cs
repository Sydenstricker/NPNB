using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private bool naveTutorialMorreu = false;

    public static bool GameisPaused = true;

    public GameObject pauseMenuUI;
    [SerializeField] bool isNave = false;
    private bool playerMorreu = false;

    private void Start()
    {
        playerMorreu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (playerMorreu == false))
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
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        //GameObject.FindWithTag("Player").GetComponent<PlayerController>().enabled = true;
        //GameObject.FindWithTag("Player").GetComponent<PlayerCav>().enabled = true;
        //GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;


        if (isNave)
        {
           FindObjectOfType<StationTutorialSaiDeCena>().NaoTiraPlataformaCenaTutorial();           

            if (naveTutorialMorreu)
            {
                FindObjectOfType<StationTutorialSaiDeCena>().TiraPlataformaCenaTutorial();
            }
        }
        
        if (!FindObjectOfType<StationTutorialSaiDeCena>()) { return; }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;        
        Cursor.visible = true;
        //GameObject.FindWithTag("Player").GetComponent<PlayerController>().enabled = false;
        //GameObject.FindWithTag("Player").GetComponent<PlayerCav>().enabled = false;
        //GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;


        if (isNave)
        {
            FindObjectOfType<StationTutorialSaiDeCena>().NaoTiraPlataformaCenaTutorial();            

            if (naveTutorialMorreu) { FindObjectOfType<StationTutorialSaiDeCena>().NaoTiraPlataformaCenaTutorial(); }
        }        
    }
    public void NaveTutorialMorreu()
    {
        naveTutorialMorreu = true;
    }

    public void PlayerMorreuNaoPermitirPausa()
    {
        playerMorreu = true;
    }
}
