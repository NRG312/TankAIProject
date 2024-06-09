using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUIEnemy : MonoBehaviour
{
    [SerializeField] private Canvas canvasGUI;
    
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private GameObject ricochetImage;
    [SerializeField] private Image sliderImage;

    #region Properties

    private float timeAnim = 0.8f;
    private bool checkingRicochet = true;
    private GameObject playerTank;

    #endregion
    private void Start()
    {
        EventManager.onRicochet.AddListener(Ricochet);
        EventManager.onTargetHitChangeGUI.AddListener(SetAmountHPOnTxt);

        playerTank = GameObject.FindWithTag("Player");
        
        RefreshUI();
    }

    private void OnDisable()
    {
        EventManager.onRicochet.RemoveListener(Ricochet);
        EventManager.onTargetHitChangeGUI.RemoveListener(SetAmountHPOnTxt);
    }

    private void RefreshUI()
    {
        hpText.text = ReturnHP().ToString();
    }

    private void Ricochet()
    {
        ricochetImage.SetActive(true);
        checkingRicochet = false;
        
        PlayAnimation("RicochetAnim");
    }

    private void Update()
    {
        //Time showing ricochet anim
        if (checkingRicochet == false)
        {
            timeAnim -= Time.deltaTime;
            if (timeAnim <= 0)
            {
                ricochetImage.SetActive(false);
                timeAnim = 0.8f;
                checkingRicochet = true;
            }
        }
        //Following Rotate to player tank
        if (canvasGUI.enabled == true)
        {
            LookAtPlayer();
        }
    }

    private void LookAtPlayer()
    {
        canvasGUI.GetComponentInChildren<RotationGUI>().LookAtPlayer(playerTank);
    }
    //Showing GUI while player is looking
    public void EnableGUI()
    {
        canvasGUI.enabled = true;
    }

    public void DisableGUI()
    {
        canvasGUI.enabled = false;
    }
    
    //Setting HP
    private void SetAmountHPOnTxt()
    {
        int hp = ReturnHP();
        hpText.text = hp.ToString();
    }
    private int ReturnHP()
    {
        return HealthSystem.instance.HP;
    }
    
    //Animations GUI
    private void PlayAnimation(string name,float crossfade = 0.2f)
    {
        ricochetImage.GetComponent<Animator>().CrossFade(name,crossfade);
    }
}