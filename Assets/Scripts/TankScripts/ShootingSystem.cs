using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootingSystem : MonoBehaviour
{
    private Animator anim;
    
    private BulletBase equipedBullet;
    private GameObject BulletObject;
    
    [Header("Shooting")]
    [SerializeField] private GameObject canonTank;
    [Space(10f)]
    [SerializeField] private int canonPenetration; //On that moment i just add more pen on various tanks
    [SerializeField] private float speedShot;
    [SerializeField] private int reloading;

    #region Properties

        private bool _reload = false;

    #endregion

    private void Start()
    {
        anim = GetComponent<Animator>();
        //Events
        EventManager.onTargetHit.AddListener(TargetHit);
        EventManager.onChangeBullet.AddListener(ChangeBullet);
        EventManager.onReloadBullet.AddListener(ReloadBullet);
    }

    private void OnDisable()
    {
        EventManager.onTargetHit.RemoveListener(TargetHit);
        EventManager.onChangeBullet.RemoveListener(ChangeBullet);
        EventManager.onReloadBullet.RemoveListener(ReloadBullet);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _reload == false)
        {
            Shoot();
        }
    }
    //Change Bullet in Tank
    private void ChangeBullet(BulletBase newBullet)
    {
        BulletObject = newBullet.gameObject;
        equipedBullet = newBullet;
        EventManager.onReloadBullet.Invoke(reloading);
    }
    //Shooting
    private void Shoot()
    {
        if (BulletObject != null)
        {
            GameObject newShell = Instantiate(BulletObject, canonTank.transform.position, canonTank.transform.rotation,canonTank.transform);
            newShell.GetComponent<Rigidbody>().velocity = speedShot * canonTank.transform.forward;
            
            EventManager.onReloadBullet.Invoke(reloading);
            EventManager.onShoot.Invoke(1);
            PlayAnimation("TurretGunAnimation");
        }
    }
    //Target Hit and deal DMG
    private void TargetHit(GameObject TargetHit,int armor)//to bedzie osobny skrypt i chyba bedzie pobieralo z danego czolgu komponent z shooting system(albo wymysle jakis lepszy skrypt pod pen)
    {
        TargetHit.GetComponent<HealthSystem>().TakeHP(equipedBullet.ReturnArmorPen() + canonPenetration ,armor,equipedBullet.ReturnDMG());
    }
    
    //Reloading Bullet
    private void ReloadBullet(int s)
    {
        _reload = true;
        StartCoroutine(TimeToReloadBullet());
    }
    private IEnumerator TimeToReloadBullet()
    {
        yield return new WaitForSeconds(reloading);
        _reload = false;
    }
    
    //Animation shooting
    private void PlayAnimation(string strin,float crossfade = 0.2f)
    {
        if (anim != null)
        {
            anim.CrossFade(strin,crossfade);
        }
    }

}