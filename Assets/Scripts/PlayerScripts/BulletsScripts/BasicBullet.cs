public class BasicBullet : BulletBase
{
    private int armorPen = 40;
    private int[] DMG;
    public override int[] ReturnDMG()
    {
        DMG = new int[2];
        DMG[0] = 50;
        DMG[1] = 75;
        return DMG;
    }

    public override int ReturnArmorPen()
    {
        return armorPen;
    }
}