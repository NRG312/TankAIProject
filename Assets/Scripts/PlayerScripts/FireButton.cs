using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void ShootButton()
    {
        player.GetComponent<ShootingSystem>().Shoot();
    }
}
