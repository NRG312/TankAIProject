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
    
    #region Properties
    
        [Header("Shooting")]
        [SerializeField] private GameObject canonTank;
        [Space(10f)]
        [SerializeField] private int canonPenetration;
        public int CanonPenetration
        {
            get { return canonPenetration; }
            private set { canonPenetration = value; }
        }
        [SerializeField] private float speedShot;
        [SerializeField] private int reloading;
    
        private bool _reload = false;
        private bool _blockShoot;

    #endregion

    private void Start()
    {
        anim = GetComponent<Animator>();
        //Events
        //EventManager.onTargetHit.AddListener(TargetHit);
        EventManager.onChangeBullet.AddListener(ChangeBullet);
        EventManager.onDeathPlayer.AddListener(BlockShooting);
    }

    private void OnDisable()
    {
        //EventManager.onTargetHit.RemoveListener(TargetHit);
        EventManager.onChangeBullet.RemoveListener(ChangeBullet);
        EventManager.onDeathPlayer.RemoveListener(BlockShooting);
    }
    
    //Change Bullet in Tank
    private void ChangeBullet(BulletBase newBullet)
    {
        BulletObject = newBullet.gameObject;
        equipedBullet = newBullet;
        EventManager.onReloadBullet.Invoke(reloading);
        ReloadBullet();
    }
    //Shooting
    public void Shoot()
    {
        if (_reload == false)
        {
            if (BulletObject != null && _blockShoot == false)
            {
                GameObject newShell = Instantiate(BulletObject, canonTank.transform.position, canonTank.transform.rotation,canonTank.transform);
                newShell.GetComponent<Rigidbody>().velocity = speedShot * canonTank.transform.forward;
            
                EventManager.onReloadBullet.Invoke(reloading);
                EventManager.onShoot.Invoke(1);
                ReloadBullet();
                PlayAnimation("TurretGunAnimation");
            }
        }
    }
    
    //Reloading Bullet
    private void ReloadBullet()
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
    
    //after death shooting is blocked
    private void BlockShooting()
    {
        _blockShoot = true;
    }

}