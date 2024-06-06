using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunPoint : MonoBehaviour
{
    [SerializeField] private GameObject pointImage;


    private void Start()
    {
        EventManager.onScoping.AddListener(Scooping);
    }

    private void OnDisable()
    {
        EventManager.onScoping.RemoveListener(Scooping);
    }

    private void Scooping()
    {
        if (!pointImage.activeInHierarchy)
        {
            pointImage.SetActive(true);
        }
        else
        {
            pointImage.SetActive(false);
        }
    }
}
