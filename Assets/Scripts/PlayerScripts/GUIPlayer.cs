using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIPlayer : MonoBehaviour
{
    private Slider _sliderHP;
    private TMP_Text _textHP;

    private void Start()
    {
        _sliderHP = GetComponent<Slider>();
        _textHP = GetComponentInChildren<TMP_Text>();
        
        //Setting GUI on start Game
        _sliderHP.maxValue = GameObject.FindWithTag("Player").GetComponent<HealthSystemPlayer>().HP;
        _sliderHP.value = GameObject.FindWithTag("Player").GetComponent<HealthSystemPlayer>().HP;
        _textHP.text = _sliderHP.value.ToString();
    }

    private void OnEnable()
    {
        EventManager.onPlayerTakeDMG.AddListener(ChangeHP);
    }

    private void OnDisable()
    {
        EventManager.onPlayerTakeDMG.RemoveListener(ChangeHP);
    }

    private void ChangeHP(int take)
    {
        _sliderHP.value -= take;
        _textHP.text = _sliderHP.value.ToString();
    }
}
