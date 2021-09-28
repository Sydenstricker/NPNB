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
    [SerializeField] bool isNaveFinalBlue = false;
    
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

        if (Input.GetKeyDown(KeyCode.Return) && isActive == true)
        {
            NextMessage();
        }

        //Nave
        if (isNaveFinalBlue == true)
        {
            FindObjectOfType<BlueAndaDialogo>().AndaNaveFinal();
            mandouTrigger = true;
        }

        if (contadorDialogo == 1 && mandouTrigger == false  && isNaveFinalBlue ==false)
        {
            FindObjectOfType<CharCutsceneController>().ExclamacaoNave();
            FindObjectOfType<BlueAndaDialogo>().AndaBlueESQ();
            mandouTrigger = true;
            
        }

        if (contadorDialogo == 27 && mandouTrigger == false && Input.GetKeyDown(KeyCode.Return) && isNaveFinalBlue == false)
        {
            FindObjectOfType<BlueAndaDialogo>().CorreDireita();
            FindObjectOfType<CharCutsceneController>().CorreNavePink();
            mandouTrigger = true;
        }

        //Exclamação Caverna
        if (contadorDialogo == 2 && mandouTrigger == false && ativaExclamacao == false)
        {
            FindObjectOfType<CharCutsceneController>().ExclamacaoTutorial();            
            mandouTrigger = true;
            ativaExclamacao = true;
        }
        
        //Olha pra trás Caverna
        if (contadorDialogo == 0 && mandouTrigger == false)
        {
            FindObjectOfType<CharCutsceneController>().OlhaAtrasTutorial();
            mandouTrigger = true;
        }
        
        //Pula Caverna
       if (contadorDialogo == 1 && mandouTrigger == false)
        {
            FindObjectOfType<CharCutsceneController>().PuloDuroTutorial();
            mandouTrigger = true;
        }          

        //Pula Blu
        if (contadorDialogo == 18 && mandouTrigger == false && isNaveFinalBlue == false)
        {
            FindObjectOfType<BlueAndaDialogo>().PulaBlue();
            mandouTrigger = true;
        }

       //CheckCaverna
       if (contadorDialogo == 13 && mandouTrigger == false)
        {
            FindObjectOfType<CharCutsceneController>().CheckTutorial();
            mandouTrigger = true;
        }

        //Troféu Caverna
        if (contadorDialogo == 1 && mandouTrigger == false)
        {
            FindObjectOfType<CharCutsceneController>().TrofeuTutorial();
            mandouTrigger = true;
        }
        
        //Old man ativa portal Caverna
        if (contadorDialogo == 6 && mandouTrigger == false)
        {
            FindObjectOfType<PortalTriggerPlayer>().VelhoAtivaPortal();
            FindObjectOfType<AnciaoScript>().AnciaoAtivaPortal();
            mandouTrigger = true;
        }
        
        //Troféu Nave
        if (contadorDialogo == 14 && mandouTrigger == false)
        {
            FindObjectOfType<CharCutsceneController>().TrofeuNave();
            mandouTrigger = true;
        }        

        //Old man procura Caverna
        if (contadorDialogo == 3)
        {
            FindObjectOfType<AnciaoScript>().AnciaoProcurando();
        }
    }
}
