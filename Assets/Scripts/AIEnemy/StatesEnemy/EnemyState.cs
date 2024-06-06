using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    public abstract EnemyState DoState(bool CanSeeThePlayer, GameObject target);
}
