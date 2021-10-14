using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovCav : MonoBehaviour
{
    public Transform playerTransform;

    void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
