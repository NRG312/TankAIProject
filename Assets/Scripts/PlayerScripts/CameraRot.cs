using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    [SerializeField] private Vector2 turn;
    [SerializeField] private float sens;
    void Update()
    {
        turn.y += Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
        turn.x += Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(-turn.y,turn.x,0);
    }
}