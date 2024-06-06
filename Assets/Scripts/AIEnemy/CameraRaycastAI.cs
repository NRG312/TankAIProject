using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraRaycastAI : MonoBehaviour
{
    private EnemyAI AI;
    [SerializeField] private Camera camera;
    private GameObject target;
    private void Start()
    {
        AI = GetComponent<EnemyAI>();
        target = GameObject.FindWithTag("Player");
    }
    private bool I_Can_See(Camera c,GameObject Object)
    {
        RaycastHit hit;
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(c);

        if (GeometryUtility.TestPlanesAABB(planes, Object.GetComponent<Collider>().bounds))
        {
            AI.canSeeThePlayer = true;
            AI.target = target;
            if (Physics.Linecast(c.transform.position,Object.GetComponent<Collider>().bounds.center,out hit))
            {
                if (hit.transform.gameObject != Object.transform.gameObject)
                {
                    AI.canSeeThePlayer = false;
                }
            }
        }
        else
        {
            AI.canSeeThePlayer = false;
        }

        return false;
    }
    

    private void Update()
    {
        if (I_Can_See(camera, target))
        {
        }
    }
}
