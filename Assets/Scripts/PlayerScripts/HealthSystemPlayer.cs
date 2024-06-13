using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystemPlayer : MonoBehaviour
{
    [SerializeField] private int m_HP;
    public int HP
    {
        get { return m_HP; }
        private set { m_HP = value; }
    }
    
    public void TakeHP(int ArmorPen,int Armor,int[] DMG)
    {
        if (ArmorPen > Armor)
        {
            int armorPen = ArmorPen - Armor;
            int highPen = armorPen * (int)1.3f;
            int randomDMG = Random.Range(DMG[0], DMG[1]);
            int DMGPen = armorPen + randomDMG + highPen;
            m_HP -= DMGPen;
            if (HP <= 0)
            {
                HP = 0;
                EventManager.onDeathPlayer.Invoke();
            }
            EventManager.onPlayerTakeDMG.Invoke(DMGPen);
            return;
        }else if (ArmorPen < Armor)
        {
            return;
        }
    }
    
}
