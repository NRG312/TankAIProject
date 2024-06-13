using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    #region Properties

        private LayerMask _layer = 1 << 6;
        private GameObject _target;
        private RaycastHit _hit;
        private Ray _ray;
        
    #endregion
    private void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray,out _hit,Mathf.Infinity,_layer))
        {
            EnableGUIEnemy();
            _target.GetComponent<GUIEnemy>().playerIsLooking = true;
        }
        else
        {
            if (_target != null)
            {
                _target.GetComponent<GUIEnemy>().playerIsLooking = false;
            }
        }
    }

    private void EnableGUIEnemy()
    {
        _target = _hit.transform.gameObject;
        _target.GetComponent<GUIEnemy>().EnableGUI();
    }
}
