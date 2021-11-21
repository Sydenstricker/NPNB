using UnityEngine;

public class BGNaveSprite : MonoBehaviour
{

    private float dist2 = 10f;
    [SerializeField] private float parallaxEffect = 1f;
       
    void Update()
    {        
        dist2 = 10f * -parallaxEffect * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + dist2, transform.position.y, transform.position.z);                
    }   

}
