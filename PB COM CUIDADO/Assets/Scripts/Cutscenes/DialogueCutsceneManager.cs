using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
    private bool bBlueNaveFinal = false;
    [SerializeField] bool isNaveDialogoFinal = false;
    [SerializeField] bool isNaveDialogoInicio = false;
    [SerializeField] bool isCaveDialogoFinal = false;
    [SerializeField] bool isCaveDialogoInicio = false;
    public bool podeProximoDialogo = true;

    //public Animator PinkyAnimator;

    Message[] currentMessages;
    Actor[] currentActors;


    int activeMessage = 0;
    public static bool isActive = false;
    private int contadorDialogo = 0;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

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
        actorImage.sprite = actorToDisplay.sprite;
        AnimateTextColor();
    }

    public void NextMessage()
    {
        mandouTrigger = false;
        activeMessage++;        

        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
            contadorDialogo++;
        }
        else
        {
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }
    }
    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }
    private IEnumerator DelayDialogos(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        yield return podeProximoDialogo = true;        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && (isActive == true) && (podeProximoDialogo == true))
        {
            podeProximoDialogo = false;
            StartCoroutine(DelayDialogos(1.4f));
            NextMessage();
        }

        if (isNaveDialogoFinal && bBlueNaveFinal == false)
        {
            FindObjectOfType<BlueAndaDialogo>().AndaBlue();
            mandouTrigger = true;
            bBlueNaveFinal = true;
        }

        if (contadorDialogo == 0)
        {
            if (isCaveDialogoInicio)
            {                
                FindObjectOfType<CharCutsceneController>().OlhaAtrasPinky();
                mandouTrigger = true;
            }
            if (isNaveDialogoFinal)
            {
                FindObjectOfType<BlueAndaDialogo>().OlhaTrasBlue();
            }
        }

        if (contadorDialogo == 1 && mandouTrigger == false)
        {
            if (isCaveDialogoInicio)
            {
                FindObjectOfType<CharCutsceneController>().PuloDuroPinky();
                mandouTrigger = true;                
            }
            if (isNaveDialogoInicio)
            {
                FindObjectOfType<CharCutsceneController>().ExclamacaoPinky();
                FindObjectOfType<BlueAndaDialogo>().ANDAPELOAMORDEDEUS();
                FindObjectOfType<BlueAndaDialogo>().AndaBlueESQ();
                mandouTrigger = true;
            }

            if (isCaveDialogoFinal)
            {
                FindObjectOfType<CharCutsceneController>().TrofeuPinky();
                mandouTrigger = true;
            }
        }
        //Exclama??o Caverna
        if (contadorDialogo == 2 && mandouTrigger == false && ativaExclamacao == false)
        {
            FindObjectOfType<CharCutsceneController>().ExclamacaoPinky();
            mandouTrigger = true;
            ativaExclamacao = true;
        }
        //Old man procura Caverna
        if (contadorDialogo == 3)
        {
            if (isCaveDialogoInicio)
            {
                FindObjectOfType<AnciaoScript>().AnciaoProcurando();
            }
        }
        //Old man ativa portal Caverna
        if (contadorDialogo == 6 && mandouTrigger == false)
        {
            if (isCaveDialogoFinal)
            {
                FindObjectOfType<AnciaoScript>().AnciaoAtivaPortal();
                mandouTrigger = true;
            }

            if (isCaveDialogoFinal)
            {
                FindObjectOfType<PortalTriggerPlayer>().VelhoAtivaPortal();
            }

        }
        if (contadorDialogo == 7 && mandouTrigger == false)
        {
            if (isNaveDialogoFinal)
            {
                FindObjectOfType<BlueAndaDialogo>().NAOSEMOVEBlue();
                mandouTrigger = true;
            }
        }
        if (contadorDialogo == 8 && mandouTrigger == false)
        {
            if (isNaveDialogoFinal)
            {
                FindObjectOfType<PortalNaveFim>().AtivaPortalNaveFim();
                FindObjectOfType<CharCutsceneController>().TrofeuPinky();
                FindObjectOfType<BlueAndaDialogo>().OlhaFrenteBlue();
                FindObjectOfType<CharCutsceneController>().OlhaAtrasFixoONPinky();
                mandouTrigger = true;
            }
        }
        if (contadorDialogo == 11 && mandouTrigger == false)
        {
            if (isNaveDialogoFinal)
            {
                FindObjectOfType<CharCutsceneController>().OlhaAtrasFixoOFFPinky();
                mandouTrigger = true;
            }
        }
        if (contadorDialogo == 12 && mandouTrigger == false)
        {
            if (isNaveDialogoFinal)
            {
                FindObjectOfType<CharCutsceneController>().OlhaAtrasFixoONPinky();
                mandouTrigger = true;
            }
        }
        //CheckCaverna
        if (contadorDialogo == 13 && mandouTrigger == false)
        {
            if (isCaveDialogoInicio)
            {
                FindObjectOfType<CharCutsceneController>().CheckPinky();
                mandouTrigger = true;
            }
        }

        if (contadorDialogo == 17 && mandouTrigger == false)
        {
            if (isNaveDialogoFinal)
            {
                FindObjectOfType<CharCutsceneController>().OlhaAtrasFixoOFFPinky();
                FindObjectOfType<CharCutsceneController>().CorrePink();
                FindObjectOfType<BlueAndaDialogo>().AndaBlue();
                mandouTrigger = true;
            }
        }

        //Pula Blu
        if (contadorDialogo == 18 && mandouTrigger == false)
        {
            if (isNaveDialogoInicio)
            {
                FindObjectOfType<BlueAndaDialogo>().PulaBlue();
                mandouTrigger = true;
            }
            if (isNaveDialogoFinal)
            {
                FindObjectOfType<CharCutsceneController>().OlhaAtrasFixoONPinky();
                mandouTrigger = true;
            }
        }
        if (contadorDialogo == 26 && mandouTrigger == false)
        {
            if (isNaveDialogoFinal)
            {
                FindObjectOfType<CharCutsceneController>().OlhaAtrasFixoOFFPinky();
                FindObjectOfType<CharCutsceneController>().CorrePink();
                FindObjectOfType<BlueAndaDialogo>().AndaBlue();
                mandouTrigger = true;
            }
        }

        if (contadorDialogo == 27 && mandouTrigger == false && Input.GetKeyDown(KeyCode.Return))
        {
            if (isNaveDialogoInicio)
            {
                FindObjectOfType<BlueAndaDialogo>().CorreDireita();
                FindObjectOfType<CharCutsceneController>().CorrePink();
                mandouTrigger = true;
            }
        }
    }
}
