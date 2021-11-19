using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosnaMorcego : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<SoundManager>().MorcegoRosna();
        }
    }
}
