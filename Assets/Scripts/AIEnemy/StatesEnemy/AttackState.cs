using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : EnemyState
{
    public ChaseState chaseState;
    [Space(5f)]
    
    #region Properties
    private bool _timeToChase;
    private float _time;
    
    private bool _isMoving = true;

    #endregion
    
    #region Base Objects
    [Header("Base Object")]
    private GameObject target;
    [HideInInspector] public Vector3 _lastPosTarget;
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private GameObject turretTank;

    #endregion

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    public override EnemyState DoState(bool canSeePlayer,GameObject target)
    {
        WaitToChasePlayer();
        if (canSeePlayer) //musze przemyslec ten skrypt bo go wysyla do chasestate a nie wyglada to za dobrze
        {
            _lastPosTarget = target.transform.position;
        }
        
        
        
        if (canSeePlayer == false && _timeToChase)
        {
            RefreshProperties();
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    private void RefreshProperties()
    {
        _timeToChase = false;
        _isMoving = true;
        nav.isStopped = false;
    }
    private void WaitToChasePlayer()
    {
        if (_isMoving == true)
        {
            StopMovingTank();
        }
        else
        {
            _time += Time.deltaTime;
            if (_time >= 5)
            {
                _time = 0;
                _timeToChase = true;
            }
        }
    }

    private void StopMovingTank()
    {
        nav.isStopped = true;
        _isMoving = false;
    }
}