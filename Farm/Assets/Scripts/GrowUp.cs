using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowUp : MonoBehaviour
{
    public float MaxTime;
    public float speed;
    public float growth;
    private bool Max;

    private void Update()
    {
        growth += 1 * Time.deltaTime;
        if (Max == false)
        {
            gameObject.transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        }
        if (growth >= MaxTime)
        {
            Max = true;
        }
    }
}
