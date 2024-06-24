using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsController : MonoBehaviour
{
    [SerializeField] private Slot[] slots;
    private Slot picSlot;
    private Slot prevSlot;

    #region Properties
        private bool blockChanging;
        private bool blockSlot1;
        private bool blockSlot2;
        private bool blockSlot3;
    #endregion
    private void Start()
    {
        EventManager.onReloadBullet.AddListener(BlockSlot);
        EventManager.onEndReload.AddListener(UnblockSlot);
    }

    private void OnDisable()
    {
        EventManager.onReloadBullet.RemoveListener(BlockSlot);
        EventManager.onEndReload.RemoveListener(UnblockSlot);
    }
    
    //While slot is reloading block changing slots
    private void BlockSlot(int s)
    {
        blockChanging = true;
    }

    private void UnblockSlot()
    {
        blockChanging = false;
    } 
    //
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && blockChanging == false && blockSlot1 == false)
        {
            ChangeSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && blockChanging == false && blockSlot2 == false)
        {
            ChangeSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && blockChanging == false && blockSlot3 == false)
        {
            ChangeSlot(2);
        }
    }
    //Sending amount of specified shells
    public void SendAmountBullets(int[] amount)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = slots[i];
            slot.SetAmountBullets(amount[i]);
        }
    }
    //Picking slot
    private void ChangeSlot(int slot)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            picSlot = slots[slot];
            if (prevSlot != null)
            {
                prevSlot.UseSlot();
            }
            prevSlot = picSlot;
            picSlot.UseSlot();
        }
    }
    
    //Permament block slot(out of ammo)
    public void BlockPermSlot(Slot _slot)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = slots[i];
            if (slot == _slot)
            {
                switch (i)
                {
                    case 2:
                        blockSlot3 = true;
                        blockChanging = false;
                        break;
                    case 1:
                        blockSlot2 = true;
                        blockChanging = false;
                        break;
                    case 0:
                        blockSlot1 = true;
                        blockChanging = false;
                        break;
                }
            }
        }
        
    }
}
