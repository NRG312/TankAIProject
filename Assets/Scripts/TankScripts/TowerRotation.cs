using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    [SerializeField]private Camera cam;
    [SerializeField] private float speedRot = 0.01f;
    private void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,cam.transform.rotation,speedRot);
        LimitRot();
    }

    private void LimitRot()
    {
        Vector3 towerRot = transform.rotation.eulerAngles;
        towerRot.x = ClampAngle(towerRot.x, -7, 7);
        transform.rotation = Quaternion.Euler(towerRot);
        transform.eulerAngles = towerRot;
    }
    private float ClampAngle(float angle, float min, float max)
    {
        if (min < 0 && max > 0 && (angle > max || angle < min))
        {
            angle -= 360;
            if (angle > max || angle < min)
            {
                if (Mathf.Abs(Mathf.DeltaAngle(angle, min)) < Mathf.Abs(Mathf.DeltaAngle(angle, max))) return min;
                else return max;
            }
        }
        else if(min > 0 && (angle > max || angle < min))
        {
            angle += 360;
            if (angle > max || angle < min)
            {
                if (Mathf.Abs(Mathf.DeltaAngle(angle, min)) < Mathf.Abs(Mathf.DeltaAngle(angle, max))) return min;
                else return max;
            }
        }
 
        if (angle < min) return min;
        else if (angle > max) return max;
        else return angle;
    }
}
