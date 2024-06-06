public class TitanBullet : BulletBase
{
    private int armorPen = 80;
    private int[] DMG;
    public override int[] ReturnDMG()
    {
        DMG = new int[2];
        DMG[0] = 100;
        DMG[1] = 150;
        return DMG;
    }
    public override int ReturnArmorPen()
    {
        return armorPen;
    }
}