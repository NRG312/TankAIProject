using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;

public class Difficult : MonoBehaviour
{
    [SerializeField] private int penEnemy;
    [SerializeField] private GameObject tankEnemy;
    
    //
    public int number;
    public int ReturnPenEnemy()
    {
        return penEnemy;
    }

    public GameObject ReturnTankEnemy()
    {
        return tankEnemy;
    }
    
}