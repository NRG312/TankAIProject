using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerRotationAI : MonoBehaviour
{
    [SerializeField] private GameObject towerTank;
    
    //Bools
    private bool _canSeeThePlayer;
    private bool _getRandomRotation;
    
    //Rotating variables
    private Quaternion _startPositionRot;
    private float _randomValue;
    
    //Time counter for new random value
    private float _time;
    
    
    private void Update()
    {
        if (_canSeeThePlayer == false)
        {
            RandomRotatePosition();
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
        towerTank.transform.localRotation =
            Quaternion.Slerp(towerTank.transform.localRotation, direction, 7f * Time.deltaTime);
        towerTank.transform.Rotate(Vector3.up * _randomValue * Time.deltaTime);

    }
}
