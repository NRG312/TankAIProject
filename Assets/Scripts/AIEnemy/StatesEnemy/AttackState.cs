using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : EnemyState
{
    public ChaseState chaseState;

    #region Properties

    private bool _reloading;
    
    private bool _timeToChase;
    private float _time;
    
    private bool _isMoving = true;
    private bool _lookingOnTarget;

    #endregion
    
    #region Objects

    [SerializeField] private GameObject target;
    [HideInInspector] public Vector3 _lastPosTarget;
    [Space(10f)] 
    [SerializeField] private NavMeshAgent nav;
    [Space(10f)] 
    [SerializeField] private GameObject turretTank;

    #endregion
    public override EnemyState DoState(bool canSeePlayer,GameObject target)
    {
        LookAtPlayer();
        _lookingOnTarget = canSeePlayer;
        if (_lookingOnTarget == true)
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
    private void LookAtPlayer()
    {
        if (_isMoving == true)
        {
            StopMovingTank();
        }

        if (_lookingOnTarget)
        {
            /*//setting angle
            Quaternion angle = Quaternion.LookRotation(target.transform.position - turretTank.transform.position);
            //look at target in a smooth transition
            Quaternion _lookOn = Quaternion.RotateTowards(turretTank.transform.rotation, angle, 6f * Time.deltaTime);
            turretTank.transform.rotation = _lookOn;*/
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
    private void Shoot()
    {
        
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(1);
    }
}