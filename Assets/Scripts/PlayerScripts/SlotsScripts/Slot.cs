using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    [SerializeField] private GameObject borderSlot;
    [SerializeField] private Slider reloadSlot;
    [SerializeField] private TMP_Text amountBulletsTxt;
    [SerializeField] private GameObject blockSlotImage;

    [Space(10f)] 
    [SerializeField] private BulletBase bulletToEquip;

    #region Properties
        private int _amountBullet;
        private bool _selected;
        private bool _reloading;
        private float _timeRealod;
        private bool _slotIsBlocked;
    #endregion
    private void Start()
    {
        amountBulletsTxt.text = _amountBullet.ToString();
        
        EventManager.onReloadBullet.AddListener(ReloadTimer);
        EventManager.onShoot.AddListener(DecreaseAmount);
    }

    private void OnDisable()
    {
        EventManager.onReloadBullet.RemoveListener(ReloadTimer);
        EventManager.onShoot.RemoveListener(DecreaseAmount);
    }
    //After select UseSlot is invoking
    public void UseSlot()
    {
        if (!borderSlot.activeInHierarchy)
        {
            borderSlot.SetActive(true);
            _selected = true;
            EventManager.onChangeBullet.Invoke(bulletToEquip);
        }
        else
        {
            borderSlot.SetActive(false);
            _selected = false;
        }
    }
    //Setting amount for bullets
    public void SetAmountBullets(int amount)
    {
        _amountBullet = amount;
        amountBulletsTxt.text = _amountBullet.ToString();
        if (amount == 0)
        {  
            BlockSlot();
        }
    }
    //Reloading Anim Slot
    private void ReloadTimer(int time)
    {
        if (_selected == true)
        {
            _reloading = true;
            _timeRealod = time;
            reloadSlot.maxValue = time;
            reloadSlot.value = time;
        }
    }

    private void Update()
    {
        if (_reloading == true && _selected == true)
        {
            _timeRealod -= Time.deltaTime;
            reloadSlot.value = _timeRealod;
            
            if (_timeRealod <= 0)
            {
                _reloading = false;
                EventManager.onEndReload.Invoke();
            }
        }
    }
    
    //Decrease Amount Bullet
    private void DecreaseAmount(int amount)
    {
        if (_selected)
        {
            _amountBullet -= amount;
            amountBulletsTxt.text = _amountBullet.ToString();
        }
    }
    
    //While amount bullet is 0 slot will be blocked
    private void BlockSlot()
    {
        blockSlotImage.SetActive(true);
        GameObject.FindWithTag("GameController").GetComponent<SlotsController>().BlockPermSlot(gameObject.GetComponent<Slot>());
    }
}
