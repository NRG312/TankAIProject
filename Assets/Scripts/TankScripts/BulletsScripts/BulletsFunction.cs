using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsFunction : MonoBehaviour
{
    [SerializeField] private GameObject shootExplosion;
    [SerializeField] private GameObject hitExplosion;

    private void Start()
    {
        Instantiate(shootExplosion,transform.position,transform.rotation);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Enemy")
        {
            Instantiate(hitExplosion,transform.position,transform.rotation);
            EventManager.onTargetHit.Invoke(other.gameObject,other.collider.GetComponent<Armor>().armor);
            EventManager.onTargetHitChangeGUI.Invoke();
            Destroy(gameObject);
        }
        else
        {
            Instantiate(hitExplosion,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
    
    
}
