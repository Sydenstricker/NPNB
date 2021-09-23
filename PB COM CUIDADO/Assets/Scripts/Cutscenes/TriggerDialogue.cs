using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerDialogue : MonoBehaviour
{
    
    public Message[] messages;
    public Actor[] actors;
    public AudioClip[] messagesSFX;
    
    
    

    public void StartDialogue()
    {
        FindObjectOfType<DialogueCutsceneManager>().OpenDialogue(messages, actors);
    }  
    
}
[System.Serializable]
public class Message
{    
    public int actorId;
    public string message;
    public AudioClip messageSFX;
    
}
[System.Serializable]
public class Actor
{
    public string name;
    //public Animator animacaoDialogo;
    public Sprite sprite;
    public Animator bonecoAnimado;
  
}


