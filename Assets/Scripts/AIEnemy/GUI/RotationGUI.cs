using UnityEngine;

public class RotationGUI : MonoBehaviour
{
    public void LookAtPlayer(GameObject playerTank)
    {
        transform.LookAt(playerTank.transform.position);
    }
}