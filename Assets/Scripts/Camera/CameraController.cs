using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    private Transform camTarget;
    private Camera gunPointCamera;
    /*[SerializeField] private float posLerp;
    [SerializeField] private float rotLerp;*/

    private bool isScoping = false;

    private float Sens = 1000f;
    private float _yaw = 0f;
    private float _pitch = 0f;

    private void Start()
    {
        camTarget = GameObject.FindWithTag("CamTarget").GetComponent<Transform>();
        gunPointCamera = GameObject.FindWithTag("GunPointCamera").GetComponent<Camera>();
    }

    public void Scoping()
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

    #region OldScript
        /*private void LateUpdate()
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
        }*/
    #endregion
    private void Update()
    {
        HandleInput();
        Quaternion yawRot = Quaternion.Euler(_pitch, 0, _yaw);
        RotateCamera(yawRot);

        if (isScoping == false)
        {
            gunPointCamera.gameObject.SetActive(false);
        }
        else
        {
            gunPointCamera.gameObject.SetActive(true);
        }
    }

    private void HandleInput()
    {
        Vector2 inputDelta = Vector2.zero;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            inputDelta = touch.deltaPosition;
        }else if (Input.GetMouseButton(0))
        {
            inputDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }

        _yaw = inputDelta.x * Sens * Time.deltaTime;
        _pitch = inputDelta.y * Sens * Time.deltaTime;
    }

    private void RotateCamera(Quaternion rot)
    {
        transform.position = camTarget.position;
        transform.rotation = camTarget.rotation;
    }
}