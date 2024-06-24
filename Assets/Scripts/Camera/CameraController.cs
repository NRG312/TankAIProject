using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    private Transform camTarget;
    private Camera gunPointCamera;
    [SerializeField] private float posLerp;
    [SerializeField] private float rotLerp;

    private bool isScoping = false;

    private void Start()
    {
        camTarget = GameObject.FindWithTag("CamTarget").GetComponent<Transform>();
        gunPointCamera = GameObject.FindWithTag("GunPointCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isScoping == true)
            {
                isScoping = false;
                EventManager.onScoping.Invoke();
                return;
            }
            EventManager.onScoping.Invoke();
            isScoping = true;
        }
    }

    private void LateUpdate()
    {
        if (isScoping == false)
        {
            gunPointCamera.gameObject.SetActive(false);
            transform.position = Vector3.Lerp(transform.position, camTarget.position, posLerp * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation,camTarget.rotation,rotLerp * Time.fixedDeltaTime);
        }else if (isScoping == true)
        {
            gunPointCamera.gameObject.SetActive(true);
            transform.position = Vector3.Lerp(transform.position, camTarget.position, posLerp * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation,camTarget.rotation,rotLerp * Time.fixedDeltaTime);
        }
    }
}