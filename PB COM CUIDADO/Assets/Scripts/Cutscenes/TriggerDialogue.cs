using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerDialogue : MonoBehaviour
{
    public int contadorDialogo = 0;
    public Message[] messages;
    public Actor[] actors;
    

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
    
    
}
[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
    
  
}


