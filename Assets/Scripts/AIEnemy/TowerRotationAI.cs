using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class TowerRotationAI : MonoBehaviour
{
    [SerializeField] private GameObject turretTank;

    [SerializeField] private float _speedRot;
    //Bools
    private bool _canSeeThePlayer;
    private bool _getRandomRotation;
    
    //Rotating variables
    private Quaternion _startPositionRot;
    private float _randomValue;
    private Vector3 _oldEulerAngles;
    
    //Time counter for new random value
    private float _time;

    private void Start()
    {
        _oldEulerAngles = turretTank.transform.eulerAngles;
    }

    private void Update()
    {
        _canSeeThePlayer = EnemyAI.instance.canSeeThePlayer;
        
        if (_canSeeThePlayer == false)
        {
            RandomRotatePosition();
        }else if (_canSeeThePlayer)
        {
            LookOnPlayer();
        }
    }
    
    private void RandomRotatePosition()
    {
        if (_getRandomRotation == false)
        {
            _randomValue = Random.Range(-4, 4);
            _getRandomRotation = true;
        }
        if (_getRandomRotation)
        {
            _time += Time.deltaTime;
            if (_time >= 6f)
            {
                _getRandomRotation = false;
                _time = 0f;
            }
        }
        
        //funtion rotating Turret Tank on random positions
        Quaternion direction = _startPositionRot * Quaternion.AngleAxis(_randomValue, Vector3.up);
        turretTank.transform.localRotation =
            Quaternion.Slerp(turretTank.transform.localRotation, direction, _speedRot * Time.deltaTime);
        turretTank.transform.Rotate(Vector3.up * _randomValue * Time.deltaTime);

    }

    private void LookOnPlayer()
    {
        //Checking that turret is rotating and send true to shoot
        if (_oldEulerAngles == turretTank.transform.eulerAngles)
        {
            EnemyAI.instance.canShoot = true;
        }else
        {
            _oldEulerAngles = turretTank.transform.eulerAngles;
            EnemyAI.instance.canShoot = false;
        }
        //Rotating to player
        //setting angle
        Quaternion angle = Quaternion.LookRotation(EnemyAI.instance.target.transform.position - turretTank.transform.position);
        //look at Player in a smooth transition
        Quaternion lookOn = Quaternion.RotateTowards(turretTank.transform.rotation, angle, 7f * Time.deltaTime);
        turretTank.transform.rotation = lookOn;
    }
}
