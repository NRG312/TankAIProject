using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : Singleton<EnemyAI>
{
    public EnemyState currentState;
    [Space(10f)]
    [HideInInspector]public bool canSeeThePlayer;
    [HideInInspector]public bool canShoot;
    [HideInInspector]public GameObject target;

    [Header("Scripts to turn off after Death")] 
    [SerializeField] private MonoBehaviour[] scripts;
    

    private void OnEnable()
    {
        EventManager.onDeathEnemy.AddListener(DeathEnemy);
    }

    private void OnDisable()
    {
        EventManager.onDeathEnemy.RemoveListener(DeathEnemy);
    }

    
    //Function States
    private void Update()
    {
        RunState();
    }

    private void RunState()
    {
        EnemyState nextState = currentState?.DoState(canSeeThePlayer,target);

        if (nextState != null)
        {
            SwitchToNextState(nextState);
        }
    }

    private void SwitchToNextState(EnemyState nextState)
    {
        currentState = nextState;
    }

    //After Death Enemy
    private void DeathEnemy()
    {
        for (int i = 0; i < scripts.Length; i++)
        {
            MonoBehaviour script = scripts[i];
            script.enabled = false;
        }
    }
}
