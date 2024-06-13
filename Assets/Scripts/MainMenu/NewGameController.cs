using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class NewGameController : MonoBehaviour
{
    public void SetTankPlayer(GameObject tank)
    {
        EventManager.onPickTankPlayer.Invoke(tank);
    }

    public void SetLevelGame(AssetReference map)
    {
        EventManager.onPickMap.Invoke(map);
    }
    
    public void SetDifficultGame(Difficult dif)
    {   
        EventManager.onPickDifficult.Invoke(dif);
    }
}
