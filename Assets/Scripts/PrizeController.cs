using UnityEngine;

public class PrizeController : MonoBehaviour
{
    // private void Awake()
    // {
    //     _collider = GetComponent<Collider2D>();
    // }
    
    private void OnTriggerStay(Collider other)
    {
        Instantiate(other.transform, transform);
    }
}
