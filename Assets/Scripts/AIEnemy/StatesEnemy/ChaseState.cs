using UnityEngine;
using UnityEngine.AI;

public class ChaseState : EnemyState
{
    public SearchingState searchState;
    public AttackState attackState;
    
    private bool _isMoving;
    private bool _seeThePlayer;
    [SerializeField] private bool onPositionPlayer;
    
    private Vector3 _lastPosPlayer;
    [SerializeField] private NavMeshAgent nav;
    
    public override EnemyState DoState(bool canSeePlayer,GameObject target)
    {
        _seeThePlayer = canSeePlayer;
        ChasePlayer();
        
        
        
        if (onPositionPlayer == true && canSeePlayer == false)
        {
            RefreshProperties();
            return searchState;
        }
        else if (canSeePlayer == true)
        {
            RefreshProperties();
            return attackState;
        }
        else
        {
            return this;
        }
    }

    private void RefreshProperties()
    {
        _isMoving = false;
        onPositionPlayer = false;
    }
    private void ChasePlayer()
    {
        if (_isMoving == false)
        {
            _lastPosPlayer = attackState._lastPosTarget;
            nav.SetDestination(_lastPosPlayer);
            _isMoving = true;
        }

        if (_isMoving == true && _seeThePlayer)
        {
            nav.ResetPath();
            _isMoving = false;
        }

        if (nav.hasPath == false)
        {
            onPositionPlayer = true;
        }
    }
}