using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.Serialization;

public class PickingTank : MonoBehaviour
{
    
    [SerializeField] private GameObject[] Tanks;
    [Space(20)]
    [SerializeField] private GameObject[] Stats;
    [Space(20)] 
    [SerializeField] private GameObject _respawnPos;
    
    private int _actualTankNumber = 0;
    private int _actualStatsNumber = 0;
    
    public void RightArrowChangeTank()
    {
        for (int i = _actualTankNumber; i < Tanks.Length; i++)
        {
            GameObject previousTank = Tanks[i];
            if (i != 2)
            {
                previousTank.SetActive(false);
                i++;
                GameObject nextTank = Tanks[i];
                nextTank.SetActive(true);
                _actualTankNumber = i;
                
                RightArrowChangeStats();
                ReloadRespawn(nextTank);
                
                return;
            }
            
        }
        
    }

    private void RightArrowChangeStats()
    {
        for (int i = _actualStatsNumber; i < Stats.Length; i++)
        {
            GameObject previousStats = Stats[i];
            if (i != 2)
            {
                previousStats.SetActive(false);
                i++;
                GameObject nextStats = Stats[i];
                nextStats.SetActive(true);
                _actualStatsNumber = i;
                
                return;
            }
            
        }
    }

    public void LeftArrowChangeTank()
    {
        for (int i = _actualTankNumber; i < Tanks.Length; i++)
        {
            GameObject previousTank = Tanks[i];
            if (i != 0)
            {
                previousTank.SetActive(false);
                i--;
                GameObject newTank = Tanks[i];
                newTank.SetActive(true);
                _actualTankNumber = i;
                
                LeftArrowChangeStats();
                ReloadRespawn(newTank);
                
                return;
            }
        }
    }

    private void LeftArrowChangeStats()
    {
        for (int i = _actualStatsNumber; i < Stats.Length; i++)
        {
            GameObject previousStats = Stats[i];
            if (i != 0)
            {
                previousStats.SetActive(false);
                i--;
                GameObject newStats = Stats[i];
                newStats.SetActive(true);
                _actualStatsNumber = i;
                
                return;
            }
        }
    }
    //Confirmed tank on scene
    public void ConfirmSelectedTank()
    {
        for (int i = 0; i < Tanks.Length; i++)
        {
            GameObject tank = Tanks[i];
            if (tank.activeInHierarchy)
            {
                GetComponent<SettingGameController>().SetTankPlayer(tank);
                PlayerPrefs.SetInt("PlayerTank",i);
            }
        }
    }
    //On change tank they will respawn on previous position
    private void ReloadRespawn(GameObject tank)
    {
        tank.transform.position = _respawnPos.transform.position;
    }
}
