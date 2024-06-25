using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speedMov;
    [SerializeField] private float speedRot;
    private Joystick _joystick;
    #region Variables
        private Rigidbody _rg;
        private Vector3 _mov;
        private float _rot;
        private float _gravity = -5f;
        private bool _blockTank;
    
    #endregion

    private void OnEnable()
    {
        EventManager.onDeathPlayer.AddListener(BlockTank);
    }

    private void OnDisable()
    {
        EventManager.onDeathPlayer.RemoveListener(BlockTank);
    }

    private void Start()
    {
        _rg = GetComponent<Rigidbody>();
        _joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    #region oldScript

        /*public void MoveTankForward()
        {
            if (_blockTank == false)
            {
                _mov = transform.forward;
                _rg.velocity = _mov * speedMov * Time.fixedDeltaTime;
                _rg.AddForce(new Vector3(0,_gravity,0) * _rg.mass * 5.7f);
            }
        }

        public void MoveTankBackward()
        {
            if (_blockTank == false)
            {
                _mov = transform.forward;
                _rg.velocity = -_mov * speedMov * Time.fixedDeltaTime;
                _rg.AddForce(new Vector3(0,_gravity,0) * _rg.mass * 5.7f);
            }
        }

        public void RotateTankLeft()
        {
            if (_blockTank == false)
            {
                _rot = speedRot * Time.deltaTime;
                _rg.MoveRotation(_rg.rotation * Quaternion.Euler(0,-_rot,0));
            }
        }
        public void RotateTankRight()
        {
            if (_blockTank == false)
            {
                _rot = speedRot * Time.deltaTime;
                _rg.MoveRotation(_rg.rotation * Quaternion.Euler(0,_rot,0));
            }
        }*/
    

    #endregion
    
    //After death block all movement and rotate tank
    private void BlockTank()
    {
        _blockTank = true;
        GetComponentInChildren<TowerRotation>().enabled = false;
    }

    private void FixedUpdate()
    {
        if (_blockTank == false)
        {
            _mov = transform.forward;
            _rg.velocity = _mov * _joystick.Vertical * speedMov * Time.fixedDeltaTime;
            _rg.AddForce(new Vector3(0,_gravity,0) * _rg.mass * 5.7f);
        }
        if (_blockTank == false)
        {
            _rot = speedRot * _joystick.Horizontal * Time.deltaTime;
            _rg.MoveRotation(_rg.rotation * Quaternion.Euler(0,_rot,0));
        }
    }


    //w przyszlosci musze zrobic zapis do gamemangera po przejsciu na nastepna scene(poziom trudnosci dodalem liczbe do nich i w samej scenie gry bedzie sprawdzala ktory czolg dodac) wszystko narazie na playerprefsach
    //Level controller tez bedzie do poprawienia przez gamemanagera
    ///
    //pozniej musze takze poprawic skrypt w bulletfunction zeby nie szukac po graczach shootingsystem
    //podczas strzalu gdy rusze wiezyczka to pocisk przemieszcza sie
    //cameracontroller fixeddelta nie dziala na timescale
    //funkcja ze jak nie widzi mnie przeciwnik i strzele do niego to widzi mnie na przyklad na 5 sekund
    //skrypt osobny na wylaczenie skryptow po wygraniu labo przegraniu przeciwnika w enemyAI
}
