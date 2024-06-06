using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SearchingState : EnemyState
{
    public AttackState attackState;
    [SerializeField] private Transform tankToMove;
    [SerializeField] private NavMeshAgent nav;

    [SerializeField] private Bounds floor;

    [SerializeField]private bool _isMovingToPosition;
    private Vector3 _randomPos;
    public override EnemyState DoState(bool canSeePlayer,GameObject target)
    {
        MovingToRandomPosition();
        if (canSeePlayer == true)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }

    private void Start()
    {
        floor = GameObject.FindWithTag("Floor").GetComponent<Renderer>().bounds;
    }
    
    private void SetRandomPos()
    {
        float rx = Random.Range(floor.min.x, floor.max.x);
        float rz = Random.Range(floor.min.z, floor.max.z);
        _randomPos = new Vector3(rx, tankToMove.transform.position.y, rz);
        nav.SetDestination(_randomPos);
        
        Invoke("CheckPoint",0.2f);
        
        _isMovingToPosition = false;
    }

    private void CheckPoint()
    {
        if (nav.pathEndPosition != _randomPos)
        {
            SetRandomPos();
        }
    }
    private void MovingToRandomPosition()
    {
        if (nav.hasPath == false && _isMovingToPosition == false)
        {
            _isMovingToPosition = true;
            SetRandomPos();
        }
    }
}
