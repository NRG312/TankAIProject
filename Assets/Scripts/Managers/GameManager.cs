using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject tankPlayer;
    [SerializeField] private Difficult selectedDifficult;

    private float _timerToStart;
    private bool _startingGame;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /*private void Update()
    {
        if (_startingGame)
        {
            _timerToStart += Time.deltaTime;
            if (_timerToStart >= 3)
            {
                SendDataToLevelController();
                _startingGame = false;
                _timerToStart = 0;
            }
        }
    }*/

    private void OnEnable()
    {
        EventManager.onPickTankPlayer.AddListener(ReplaceTank);
        EventManager.onPickDifficult.AddListener(ReplaceDifficult);
        EventManager.onStartNewGame.AddListener(LoadingMap);
    }

    private void OnDisable()
    {
        EventManager.onPickTankPlayer.RemoveListener(ReplaceTank);
        EventManager.onPickDifficult.RemoveListener(ReplaceDifficult);
        EventManager.onStartNewGame.RemoveListener(LoadingMap);
    }

    private void ReplaceTank(GameObject tank)
    {
        tankPlayer = tank;
    }

    private void ReplaceDifficult(Difficult dif)
    {
        selectedDifficult = dif;
    }
    //After reload new Map game manager sends Data to level controller
    private void LoadingMap()
    {
        //_startingGame = true;
        SendDataToLevelController();
    }
    private void SendDataToLevelController()
    {
        EventManager.onPickDifficult.Invoke(selectedDifficult);
        EventManager.onPickTankPlayer.Invoke(tankPlayer);
    }
}
