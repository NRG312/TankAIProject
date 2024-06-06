using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAnimation : MonoBehaviour
{
    private float time;
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3f)
        {
            Destroy(gameObject);
        }
    }
}
