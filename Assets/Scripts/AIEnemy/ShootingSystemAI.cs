using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystemAI : MonoBehaviour
{
    [SerializeField] private GameObject projectTile;
    [SerializeField] private GameObject positionShoot;
    [Space(10f)]
    [SerializeField] private int timeReloading;
    [SerializeField] private float speedShot;

    private bool _isReloading;
    private IEnumerator coroutine;
    
    private void Start()
    {
        coroutine = Reload(timeReloading);
    }

    private void Update()
    {
        if (EnemyAI.instance.canShoot == true)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_isReloading == false)
        {
            GameObject newShell = Instantiate(projectTile, positionShoot.transform.position, positionShoot.transform.rotation,positionShoot.transform);
            newShell.GetComponent<Rigidbody>().velocity = speedShot * positionShoot.transform.forward;
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator Reload(int reloading)
    {
        _isReloading = true;
        yield return new WaitForSeconds(reloading);
        _isReloading = false;
        StopCoroutine(coroutine);
    }
}
