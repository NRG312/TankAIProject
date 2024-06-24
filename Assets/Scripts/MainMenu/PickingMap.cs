using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingMap : MonoBehaviour
{
    [SerializeField] private GameObject Map1;
    [SerializeField] private GameObject Map2;


    public void LeftArrow()// pozniej jakby bylo wiecej map to zmienie te funkcje
    {
        if (Map1.activeInHierarchy)
        {
            Map1.SetActive(false);
            Map2.SetActive(true);
        }
        else
        {
            Map2.SetActive(false);
            Map1.SetActive(true);
        }
    }

    public void RightArrow()
    {
        if (Map1.activeInHierarchy)
        {
            Map1.SetActive(false);
            Map2.SetActive(true);
        }
        else
        {
            Map2.SetActive(false);
            Map1.SetActive(true);
        }
    }

    public void ConfirmMap()
    {
        if (Map1.activeInHierarchy)
        {
            GetComponent<SettingGameController>().SetLevelGame("Map1");
        }
        else
        {
            GetComponent<SettingGameController>().SetLevelGame("Map2");
        }
    }
}
