using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPlus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CornPlusText.CornPlus < 40)
            {
                CornPlusText.CornPlus -= 10;
                MoneyText.MoneyPlus += 15;
            }
        }
    }
}
