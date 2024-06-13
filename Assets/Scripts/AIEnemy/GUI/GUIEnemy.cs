using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUIEnemy : MonoBehaviour
{
    #region ObjectsScene

    [SerializeField] private Canvas canvasGUI;
    [Space(10)]
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text dealedDmg;
    [Space(10f)]
    [SerializeField] private GameObject ricochetImage;
    [SerializeField] private Slider sliderImage;

    #endregion

    #region Properties

    private float _timeAnim = 0.8f;
    private float _timerEnabling;
    private bool _checkingRicochet = false;
    private bool _checkingDealDmg = false;
    [HideInInspector]public bool playerIsLooking;

    #endregion
    private void Start()
    {
        EventManager.onRicochet.AddListener(Ricochet);
        EventManager.onTargetHitChangeGUI.AddListener(ChangeAmountOnGUI);
        
        RefreshUI();
    }

    private void OnDisable()
    {
        EventManager.onRicochet.RemoveListener(Ricochet);
        EventManager.onTargetHitChangeGUI.RemoveListener(ChangeAmountOnGUI);
    }

    private void RefreshUI()
    {
        hpText.text = ReturnHP().ToString();
        sliderImage.maxValue = GetComponent<HealthSystemEnemy>().HP;
        sliderImage.value = ReturnHP();
    }

    private void Ricochet()
    {
        ricochetImage.SetActive(true);
        _checkingRicochet = true;
        
        PlayAnimationRicochet("RicochetAnim");
    }

    private void Update()
    {
        //Timer showing GUI Anim
        if (_checkingRicochet == true)
        {
            TurnOffRicochetImage();
        }

        if (_checkingDealDmg == true)
        {
            TurnOffDealDmgImage();
        }
        
        //Following Rotate to player tank & after 10 seconds while player is not looking gui is turning off
        if (canvasGUI.enabled == true)
        {
            LookAtPlayer();
            if (playerIsLooking == false)
            {
                _timerEnabling += Time.deltaTime;
                if (_timerEnabling >= 10)
                {
                    _timerEnabling = 0;
                    canvasGUI.enabled = false;
                }
            }
            else
            {
                _timerEnabling = 0;
            }
        }
    }

    private void LookAtPlayer()
    {
        canvasGUI.GetComponentInChildren<RotationGUI>().LookAtPlayer();
    }
    //Showing GUI while player is looking
    public void EnableGUI()
    {
        canvasGUI.enabled = true;
    }
    //Setting HP
    private void ChangeAmountOnGUI()
    {
        if (_checkingRicochet == false)
        {
            int hp = ReturnHP();
            hpText.text = hp.ToString();
            
            //Getting value of dmg and set that to text
            _checkingDealDmg = true;
            dealedDmg.gameObject.SetActive(true);
            dealedDmg.text = "-" + GetValueDMG(hp).ToString();
            PlayAnimationDealedDMG("DealedDMGAnim");
        }
    }
    //Getting value of dmg and set that to slider
    private int GetValueDMG(int hp)
    {
        int dealedDMG = (int)sliderImage.value;
        sliderImage.value = hp;
        dealedDMG -= (int)sliderImage.value;
        return dealedDMG;
    }
    private int ReturnHP()
    {
        int Hp = GetComponent<HealthSystemEnemy>().HP;
        return Hp;
    }
    
    //Animations GUI
    private void PlayAnimationRicochet(string name,float crossfade = 0.2f)
    {
        ricochetImage.GetComponent<Animator>().CrossFade(name,crossfade);
    }

    private void PlayAnimationDealedDMG(string name, float crossfade = 0.2f)
    {
        dealedDmg.GetComponent<Animator>().CrossFade(name,crossfade);
    }
    //Turning off images after timer is done
    private void TurnOffRicochetImage()
    {
        _timeAnim -= Time.deltaTime;
        if (_timeAnim <= 0)
        {
            ricochetImage.SetActive(false);
            _timeAnim = 0.8f;
            _checkingRicochet = false;
        }
    }

    private void TurnOffDealDmgImage()
    {
        _timeAnim -= Time.deltaTime;
        if (_timeAnim <= 0)
        {
            dealedDmg.gameObject.SetActive(false);
            _timeAnim = 0.8f;
            _checkingDealDmg = false;
        }
    }
}