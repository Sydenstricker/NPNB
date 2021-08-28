using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public TextAsset file;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<DialogManager>().StartDialog(file);
            FindObjectOfType<PlayerController>().isDialogNaoPulaCacete = true;           
            Destroy(gameObject.GetComponent<Collider2D>());            
        }        
    }
  
}
