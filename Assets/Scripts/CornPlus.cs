using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornPlus : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectCorn;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CornPlusText.CornPlus < 40)
            {
                CornPlusText.CornPlus += 10;
                Destroy(gameObjectCorn);
            }
        }
    }
}
