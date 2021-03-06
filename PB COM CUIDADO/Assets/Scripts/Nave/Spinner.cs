using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float speedOfSpin = 1f;
    void Update()
    {
        transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);
    }
}
