using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystemAI : MonoBehaviour
{
    [SerializeField] private GameObject projectTile;
    [SerializeField] private GameObject positionShoot;
    [Space(10f)] 
    public int canonPenetration;
    public int CanonPenetration
    {
        get { return canonPenetration; }
        set { canonPenetration = value; }
    }
    [SerializeField] private int timeReloading;
    [SerializeField] private float speedShot;

    private bool _isReloading = false;
    private float _timer;
    

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
            GameObject newShell = Instantiate(projectTile, positionShoot.transform.position, positionShoot.transform.rotation);
            newShell.GetComponent<Rigidbody>().velocity = speedShot * positionShoot.transform.forward;
            ReloadBullet();
        }
    }
    
    private void ReloadBullet()
    {
        _isReloading = true;
        StartCoroutine(TimeToReloadBullet());
    }
    private IEnumerator TimeToReloadBullet()
    {
        yield return new WaitForSeconds(timeReloading);
        _isReloading = false;
    }
    
}
