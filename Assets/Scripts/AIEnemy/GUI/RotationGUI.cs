using System;
using UnityEngine;

public class RotationGUI : MonoBehaviour
{
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    public void LookAtPlayer()
    {
        transform.LookAt(_player.transform.position);
    }
}