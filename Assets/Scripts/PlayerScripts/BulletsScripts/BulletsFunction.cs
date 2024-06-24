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

    #region Properties
        private GameObject _player;
        private GameObject _enemy;
        private bool isHit;
    #endregion
    private void Start()
    {
        _player = GameObject.FindWithTag("Player"); 
        _enemy = GameObject.FindWithTag("Enemy");
        Instantiate(shootExplosion,transform.position,transform.rotation);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isHit)
        {
            isHit = true;
            StartCoroutine(CollDown());
            
            if (other.collider.tag == "EnemyArmorCollider")
            {
                HitEnemy(other);
            }else if (other.collider.tag == "PlayerArmorCollider")
            {
                HitPlayer(other);
            }
            else
            {
                Instantiate(hitExplosion,transform.position,transform.rotation);
                Destroy(gameObject);
            }
        }
    }
    //Colldown to not hit multiplie colliders in tanks
    private IEnumerator CollDown()
    {
        yield return new WaitForSeconds(0.1f);
        isHit = false;
    }

    private void HitEnemy(Collision other)
    {
        Instantiate(hitExplosion,transform.position,transform.rotation);
        other.collider.GetComponentInParent<HealthSystemEnemy>().TakeHP(equipedBullet.ReturnArmorPen() + _player.GetComponent<ShootingSystem>().CanonPenetration,other.collider.GetComponent<Armor>().armor,equipedBullet.ReturnDMG());
        EventManager.onTargetHitChangeGUI.Invoke();
        Destroy(gameObject);
    }

    private void HitPlayer(Collision other)
    {
        Instantiate(hitExplosion,transform.position,transform.rotation);
        other.collider.gameObject.GetComponentInParent<HealthSystemPlayer>().TakeHP(equipedBullet.ReturnArmorPen() + _enemy.GetComponent<ShootingSystemAI>().CanonPenetration,other.collider.GetComponent<Armor>().armor,equipedBullet.ReturnDMG());
        Destroy(gameObject);
    }
    
}
