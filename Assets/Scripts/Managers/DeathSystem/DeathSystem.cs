using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSystem : MonoBehaviour
{
    private GameObject _playerTank;
    private GameObject _enemyTank;
    private MeshRenderer[] _playerMesh;
    private MeshRenderer[] _enemyMesh;
    
    private bool _playerWin;
    private bool _enemyWin;
    private float _timer;
    
    [Header("Death Tanks Components")]
    [SerializeField] private GameObject explosionSfx;

    [Header("Death Material")] 
    [SerializeField] private Material deathMaterial;

    private void Start()
    {
        _playerTank = GameObject.FindWithTag("Player");
        _enemyTank = GameObject.FindWithTag("Enemy");
        _playerMesh = _playerTank.GetComponentsInChildren<MeshRenderer>();
        _enemyMesh = _enemyTank.GetComponentsInChildren<MeshRenderer>();
    }
    private void Update()
    {
        if (_playerWin)
        {
            _timer += Time.deltaTime;
            if (_timer >= 5)
            {
                EventManager.onPlayerWin.Invoke();
                _playerWin = false;
                _timer = 0;
            }
        }else if (_enemyWin)
        {
            _timer += Time.deltaTime;
            if (_timer >= 5)
            {
                EventManager.onEnemyWin.Invoke();
                _enemyWin = false;
                _timer = 0;
            }
        }
    }

    private void OnEnable()
    {
        EventManager.onDeathEnemy.AddListener(DeathEnemy);
        EventManager.onDeathPlayer.AddListener(DeathPlayer);
    }

    private void OnDisable()
    {
        EventManager.onDeathEnemy.RemoveListener(DeathEnemy);
        EventManager.onDeathPlayer.RemoveListener(DeathPlayer);
    }

    private void DeathEnemy()
    {
        for (int i = 0; i < _enemyMesh.Length; i++)
        {
            MeshRenderer mesh = _enemyMesh[i];
            for (int j = 0; j < mesh.materials.Length; j++)
            {
                Material deathMat = mesh.materials[j];
                deathMat.color = deathMaterial.color;
            }
        }
    }

    private void DeathPlayer()
    {
        for (int i = 0; i < _playerMesh.Length; i++)
        {
            MeshRenderer mesh = _playerMesh[i];
            for (int j = 0; j < mesh.materials.Length; j++)
            {
                Material deathMat = mesh.materials[j];
                deathMat.color = deathMaterial.color;
            }
        }
    }
}
