using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovCav : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
