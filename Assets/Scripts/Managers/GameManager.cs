using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AssetReference Map;
    [SerializeField] private GameObject tankPlayer;
    [SerializeField] private Difficult selectedDifficult;
    private void OnEnable()
    {
        EventManager.onPickTankPlayer.AddListener(ReplaceTank);
        EventManager.onPickDifficult.AddListener(ReplaceDifficult);
        EventManager.onPickMap.AddListener(ReplaceMap);
    }

    private void OnDisable()
    {
        EventManager.onPickTankPlayer.RemoveListener(ReplaceTank);
        EventManager.onPickDifficult.RemoveListener(ReplaceDifficult);
        EventManager.onPickMap.RemoveListener(ReplaceMap);
    }

    private void ReplaceTank(GameObject tank)
    {
        tankPlayer = tank;
    }

    private void ReplaceMap(AssetReference map)
    {
        Map = map;
    }

    private void ReplaceDifficult(Difficult dif)
    {
        selectedDifficult = dif;
    }
    //After reload new Map game manager sends Data to level controller
    private void SendDataToLevelController()
    {
        EventManager.onPickMap.Invoke(Map);
        EventManager.onPickDifficult.Invoke(selectedDifficult);
        EventManager.onPickTankPlayer.Invoke(tankPlayer);
    }
}
