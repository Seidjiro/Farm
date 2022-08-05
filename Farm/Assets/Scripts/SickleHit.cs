using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleHit : MonoBehaviour
{
    //ссылки на префабы 
    [SerializeField] private GameObject corn;
    [SerializeField] private Transform point;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Corn"))
        {
            Destroy(other.gameObject);
            Instantiate(corn, point.position, point.rotation);
        }
    }
}
