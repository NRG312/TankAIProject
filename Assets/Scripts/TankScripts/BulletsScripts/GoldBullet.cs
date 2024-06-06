public class GoldBullet : BulletBase
{
    private int armorPen = 55;
    private int[] DMG;
    public override int[] ReturnDMG()
    {
        DMG = new int[2];
        DMG[0] = 75;
        DMG[1] = 100;
        return DMG;
    }
    public override int ReturnArmorPen()
    {
        return armorPen;
    }
}