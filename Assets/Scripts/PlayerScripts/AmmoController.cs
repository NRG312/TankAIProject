using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AmmoController : MonoBehaviour
{
    private SlotsController LevelController;
    
    [SerializeField] private int[] amountBullets;
    void Start()
    {
        LevelController = GameObject.FindWithTag("GameController").GetComponent<SlotsController>();
        LoadData();
    }

    private void LoadData()
    {
        amountBullets[0] = 10;           //na ten moment nie wprowadzilem funkcji na rozne ilosci amunicji do czolgow
        amountBullets[1] = 10;
        amountBullets[2] = 5;
        SendDataOnStartGame();
    }
    private void SendDataOnStartGame()
    {
        LevelController.SendAmountBullets(amountBullets);
    }
}
