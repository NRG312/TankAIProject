using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    //Tank Funtion Events
    public static UnityEvent<BulletBase> onChangeBullet = new UnityEvent<BulletBase>();
    public static UnityEvent<int> onReloadBullet = new UnityEvent<int>();
    public static UnityEvent onEndReload = new UnityEvent();
    //Shooting system Events
    public static UnityEvent<int> onShoot = new UnityEvent<int>();
    public static UnityEvent<GameObject,int> onTargetHit = new UnityEvent<GameObject,int>();
    public static UnityEvent onTargetHitChangeGUI = new UnityEvent();
    public static UnityEvent onRicochet = new UnityEvent();
    public static UnityEvent onScoping = new UnityEvent();
    //Player Events
    public static UnityEvent onPlayerWin = new UnityEvent();
    public static UnityEvent onPlayerDead = new UnityEvent();
    
    //Start Game Events
    //public static UnityEvent<int, int, int> onAmountBullets = new UnityEvent<int, int, int>();         moge uzyc delegate i wtedy bede mial 3 rozne dane w 1 delegacie
    public static UnityEvent<GameObject> onPickTankPlayer = new UnityEvent<GameObject>();
    public static UnityEvent<GameObject> onPickTankEnemy = new UnityEvent<GameObject>();

}
