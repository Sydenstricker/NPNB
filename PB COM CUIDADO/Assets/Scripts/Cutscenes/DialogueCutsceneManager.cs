using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCutsceneManager : MonoBehaviour
{
    public Image actorImage;
    //public Animator actorAnimator;
    public Text actorName;
    public Text messageText;
    public AudioClip messageSFX;
    public RectTransform backgroundBox;
    private bool ativaExclamacao = false;
    private bool mandouTrigger = false;
    
    //public Animator PinkyAnimator;

    Message[] currentMessages;
    Actor[] currentActors;
    
    //AudioClip[] currentSFX;
    int activeMessage = 0;
    //int activeSFX = 0;
    public static bool isActive = false;

    //[SerializeField] AudioClip [] messageSFX;
    //[SerializeField] AudioClip questCompleta;
    //[SerializeField] AudioClip dialogo6;
    private int contadorDialogo = 0;
    

        public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        //currentSFX = messages;
        activeMessage = 0;
        //activeSFX = 0;

        isActive = true;
        
        Debug.Log("Started conversation! Loaded messages: " + messages.Length);
        DisplayMessage();

        backgroundBox.LeanScale(Vector3.one, 0.5f);
        
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;
        messageSFX = messageToDisplay.messageSFX;
        AudioSource.PlayClipAtPoint(messageSFX, Camera.main.transform.position, 0.6f);
                
        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        //actorAnimator = actorToDisplay.bonecoAnimado; 
        actorImage.sprite = actorToDisplay.sprite;        

        AnimateTextColor();
    }

    public void NextMessage()
    {
        mandouTrigger = false;
        activeMessage++;
        //activeSFX++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
            //PlayDialogueSFX();
            contadorDialogo++;
        }
       
        else {
            Debug.Log("Conversation ended!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }
            
    }
      

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
        //PinkyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isActive == true) {
            NextMessage();            
        }
        if (contadorDialogo == 2 && mandouTrigger == false  )
        {
            FindObjectOfType<CharCutsceneController>().ExclamacaoNave();
            FindObjectOfType<BlueAndaDialogo>().AndaBlueESQ();
            mandouTrigger = true;
            
        }

        if (contadorDialogo == 4 && mandouTrigger == false && ativaExclamacao == true)
        {
            FindObjectOfType<CharCutsceneController>().ExclamacaoTutorial();            
            mandouTrigger = true;
            ativaExclamacao = false;
        }
        
        if (contadorDialogo == 1 && mandouTrigger == false)
        {
            FindObjectOfType<CharCutsceneController>().OlhaAtrasTutorial();
            mandouTrigger = true;
        }
        if (contadorDialogo == 3 && mandouTrigger == false)
        {
            FindObjectOfType<CharCutsceneController>().PuloDuroTutorial();
            mandouTrigger = true;
            ativaExclamacao = true;
        }             

        if (contadorDialogo == 26 && mandouTrigger == false)
        {
            FindObjectOfType<CharCutsceneController>().CheckTutorial();
            FindObjectOfType<BlueAndaDialogo>().PulaBlue();
            mandouTrigger = true;
        }
        if (contadorDialogo == 5 && mandouTrigger == false)
        {
            FindObjectOfType<CharCutsceneController>().TrofeuTutorial();
            mandouTrigger = true;
        }
        if (contadorDialogo == 36 && mandouTrigger == false && Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<BlueAndaDialogo>().CorreDireita();
            FindObjectOfType<CharCutsceneController>().CorreNavePink();
            mandouTrigger = true;
        }

        if (contadorDialogo == 15 && mandouTrigger == false)
        {
            FindObjectOfType<PortalTriggerPlayer>().VelhoAtivaPortal();
            FindObjectOfType<AnciaoScript>().AnciaoAtivaPortal();
            mandouTrigger = true;
        }
        if (contadorDialogo == 14 && mandouTrigger == false)
        {
            FindObjectOfType<CharCutsceneController>().TrofeuNave();
            mandouTrigger = true;
        }        

        if (contadorDialogo == 4)
        {
            FindObjectOfType<AnciaoScript>().AnciaoProcurando();
        }
    }
}
