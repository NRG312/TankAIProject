using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHolding : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button buttonObj;
    public bool buttonPressed;

    private void Start()
    {
        buttonObj = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData){
        buttonPressed = true;
    }
 
    public void OnPointerUp(PointerEventData eventData){
        buttonPressed = false;
    }

    private void FixedUpdate()
    {
        if (buttonPressed)
        {
            buttonObj.onClick.Invoke();
        }
    }
}
