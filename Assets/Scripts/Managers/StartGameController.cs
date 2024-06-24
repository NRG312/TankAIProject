using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : MonoBehaviour
{
    [SerializeField] private GameObject[] tankPlayer;
    private GameObject _pickedTank;
    [SerializeField] private Difficult[] selectedDifficult;
    private Difficult _pickedDifficult;
    [Space(10f)] 
    [SerializeField] private GameObject spawnPointPlayer;
    [SerializeField] private GameObject spawnPointEnemy;

    private void Awake()
    {
        _pickedTank = tankPlayer[PlayerPrefs.GetInt("PlayerTank")];
        _pickedDifficult = selectedDifficult[PlayerPrefs.GetInt("EnemyDifficult")];
        SpawnPlayer();
        SpawnEnemy();
    }


    /*private void OnEnable()
    {
        EventManager.onPickTankPlayer.AddListener(ReplaceTank);
        EventManager.onPickDifficult.AddListener(ReplaceDifficult);
    }

    private void OnDisable()
    {
        EventManager.onPickTankPlayer.RemoveListener(ReplaceTank);
        EventManager.onPickDifficult.RemoveListener(ReplaceDifficult);
    }*/
    //Replacing Data
    /*private void ReplaceTank(GameObject tank)
    {
        tankPlayer = tank;
        SpawnPlayer();
    }

    private void ReplaceDifficult(Difficult dif)
    {
        selectedDifficult = dif;
        PlayerPrefs.SetInt("EnemyDifficult",dif.number);
        SpawnEnemy();
    }*/
    //Spawning Tanks
    private void SpawnPlayer()
    {
        Instantiate(_pickedTank, spawnPointPlayer.transform.position, spawnPointPlayer.transform.rotation);
    }

    private void SpawnEnemy()
    {
        GameObject enemytank = Instantiate(_pickedDifficult.ReturnTankEnemy(), spawnPointEnemy.transform.position,
            spawnPointEnemy.transform.rotation);
        enemytank.GetComponent<ShootingSystemAI>().CanonPenetration = _pickedDifficult.ReturnPenEnemy();
    }
}
