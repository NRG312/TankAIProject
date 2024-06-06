using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyState currentState;
    [Space(10f)] 
    //public AttackState attackState;


    public bool canSeeThePlayer;
    [HideInInspector]public GameObject target;
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


    public void OnTakeDMG()// to musze przemyusles
    {
        //currentState = attackState;
    }
}
