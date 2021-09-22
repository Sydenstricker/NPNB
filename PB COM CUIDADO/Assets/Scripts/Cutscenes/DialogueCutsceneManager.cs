using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCutsceneManager : MonoBehaviour
{
    public Image actorImage;
    public Animator actorAnimator;
    public Text actorName;
    public Text messageText;
    public AudioClip messageSFX;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    //AudioClip[] currentSFX;
    int activeMessage = 0;
    //int activeSFX = 0;
    public static bool isActive = false;

    //[SerializeField] AudioClip [] messageSFX;
    //[SerializeField] AudioClip questCompleta;
    //[SerializeField] AudioClip dialogo6;
    //private int contadorDialogo = 0;
    

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
        actorAnimator = actorToDisplay.bonecoAnimado; 
        actorImage.sprite = actorToDisplay.sprite;        

        AnimateTextColor();
    }

    public void NextMessage()
    {
        
        activeMessage++;
        //activeSFX++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
            //PlayDialogueSFX();
            //contadorDialogo++;
        }
        else {
            Debug.Log("Conversation ended!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }
            
    }

    /*private static void PlayDialogueSFX()
    {
        //AudioClip messageSFX = currentSFX[activeSFX];
        //AudioClip().PlayOnShot(currentSFX);
       
        //GetComponent<AudioSource>().PlayOneShot(currentSFX);

        //GetComponent<AudioSource>().PlayOneShot(messageSFX);
        //Message soundToDisplay = currentSFX[];
        //GetComponent<AudioSource>().PlayOneShot(currentSFX);
        //Message messageToDisplay = currentMessages[activeMessage];


        //Message audiotoDisplay = currentMessages[PlayDialogueSFX];


        //GetComponent<TriggerDialogue>(Message).messages;
        //FindObjectOfType<TriggerDialogue>().Message.messageSFX;
        //GetComponent<TriggerDialogue>().AudioClip.PlayOneShot(messageSFX);
        //GetComponent<AudioSource>().PlayOneShot(messageSFX);
    }*/

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isActive == true) {
            NextMessage();            
        }
        /*if (contadorDialogo == 5)
        {
            //AudioSource.PlayOneShot(questCompleta);
            GetComponent<AudioSource>().PlayOneShot(questCompleta);
            Debug.Log("tocou quest completed SFX");
            contadorDialogo++;
        } 
        */
    }
}
