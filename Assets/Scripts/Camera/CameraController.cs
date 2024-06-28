using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    private Transform camTarget;
    private Camera gunPointCamera;

    private bool isScoping = false;
    


    private float Y_min = -50f;
    private float Y_max = 50;

    private float cur_x = 0f;
    private float cur_y = 0f;

    [SerializeField]private float camera_dis = 50f;
    [SerializeField]private float camera_sens = 15f;

    [SerializeField] private Joystick joy;

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
        if (isScoping == false)
        {
            gunPointCamera.gameObject.SetActive(false);
        }
        else
        {
            gunPointCamera.gameObject.SetActive(true);
        }
    }

    private void LateUpdate()
    {
        cur_x += joy.Horizontal * camera_sens * Time.deltaTime;
        cur_y -= joy.Vertical * camera_sens * Time.deltaTime;
        cur_y = Mathf.Clamp(cur_y, Y_min, Y_max);

        Vector3 dir = new Vector3(0, 0, -camera_dis);
        Quaternion rot = Quaternion.Euler(cur_y, cur_x, 0);

        transform.position = camTarget.position + rot * dir;
        
        transform.LookAt(camTarget.position);
    }
}