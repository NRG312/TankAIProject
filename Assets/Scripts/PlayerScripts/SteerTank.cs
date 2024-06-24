using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteerTank : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [Header("Buttons")] 
    [SerializeField] private Button upButton;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void RotateTankRight()
    {
        player.GetComponent<PlayerInput>().RotateTankRight();
    }
    public void RotateTankLeft()
    {
        player.GetComponent<PlayerInput>().RotateTankLeft();
    }
}
