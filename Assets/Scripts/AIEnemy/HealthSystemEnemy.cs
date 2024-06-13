using UnityEngine;

public class HealthSystemEnemy : MonoBehaviour
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
            return;
        }else if (ArmorPen < Armor)
        {
            EventManager.onRicochet.Invoke();
            return;
        }
    }
    
}