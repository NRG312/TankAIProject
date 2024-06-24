using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class SettingGameController : MonoBehaviour
{
    public void SetTankPlayer(GameObject tank)
    {
        EventManager.onPickTankPlayer.Invoke(tank);
    }
    public void SetDifficultGame(Difficult dif)
    {   
        EventManager.onPickDifficult.Invoke(dif);
        PlayerPrefs.SetInt("EnemyDifficult",dif.number);
    }
    public void SetLevelGame(string map)
    {
        SceneManager.LoadScene(map);
        EventManager.onStartNewGame.Invoke();
    }
}
