using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    public static int MoneyPlus;
    private int previousValue;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        if (MoneyPlus != previousValue)
        {
            text.text = MoneyPlus.ToString();
            previousValue = MoneyPlus;
        }
    }
}
