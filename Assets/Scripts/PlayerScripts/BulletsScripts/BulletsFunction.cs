using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsFunction : MonoBehaviour
{
    [SerializeField] private GameObject shootExplosion;
    [SerializeField] private GameObject hitExplosion;
    [Space(10f)] 
    [SerializeField] private BulletBase equipedBullet;

    private GameObject _player;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        Instantiate(shootExplosion,transform.position,transform.rotation);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Enemy")
        {
            Instantiate(hitExplosion,transform.position,transform.rotation);
            other.collider.GetComponentInParent<HealthSystemEnemy>().TakeHP(equipedBullet.ReturnArmorPen() + _player.GetComponent<ShootingSystem>().CanonPenetration,other.collider.GetComponent<Armor>().armor,equipedBullet.ReturnDMG());
            //EventManager.onTargetHit.Invoke(other.gameObject,other.collider.GetComponent<Armor>().armor);
            EventManager.onTargetHitChangeGUI.Invoke();
            Destroy(gameObject);
        }else if (other.collider.tag == "PlayerArmorCollider")
        {
            Instantiate(hitExplosion,transform.position,transform.rotation);
            other.collider.gameObject.GetComponentInParent<HealthSystemPlayer>().TakeHP(equipedBullet.ReturnArmorPen() + 50,other.collider.GetComponent<Armor>().armor,equipedBullet.ReturnDMG());
            Destroy(gameObject);
        }
        else
        {
            Instantiate(hitExplosion,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
    
    
}
