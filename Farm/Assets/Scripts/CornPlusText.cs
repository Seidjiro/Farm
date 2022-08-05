using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CornPlusText : MonoBehaviour
{
    public static int CornPlus;
    private int previousValue;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();         
    }

    private void Update()
    {
        if (CornPlus != previousValue)
        {
            text.text = CornPlus.ToString();
            previousValue = CornPlus;
        }    
    }
}
