using UnityEngine;

public class BGNaveSprite : MonoBehaviour
{

    private float dist2 = 10f;
    [SerializeField] private float parallaxEffect = 1f;
    private float contaTempo = 0f;
    [SerializeField] float tempoSpawnaProxBG = 2f;
    [SerializeField] float distanciaNovoBGx = 10f;
    [SerializeField] float distanciaNovoBGy = 10f;
    [SerializeField] float distanciaNovoBGz = 10f;

    void Update()
    {
        contaTempo++;
        //dist = -contaTempo * Time.deltaTime * parallaxEffect;
        dist2 = 10f * -parallaxEffect * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + dist2, transform.position.y, transform.position.z);

        if ((Time.deltaTime * tempoSpawnaProxBG) == contaTempo)
        {
            SpawnaProxBG();
            contaTempo = 0;
        }
    }

    private void SpawnaProxBG()
    {
        transform.position = new Vector3(distanciaNovoBGx, distanciaNovoBGy, distanciaNovoBGz);
        Debug.Log("bg SPRITE teleportou");
        /*
        new Vector2 = 
            Instantiate(
            this.gameObject,
            transform.position,
            Quaternion.identity) as GameObject;
        Destroy(gameObject);
        */
    }

}
