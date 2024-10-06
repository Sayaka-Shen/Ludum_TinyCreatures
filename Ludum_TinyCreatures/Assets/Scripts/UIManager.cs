using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private TextMeshProUGUI _txtMinute;
    [SerializeField] private TextMeshProUGUI _txtSeconds;

    [Header("Sheep")] 
    [SerializeField] private TextMeshProUGUI _txtSheepCount;

    private void Update()
    {
        UpdateTimerUI();
        UpdateSheepCountUI();
    }


    private void UpdateTimerUI()
    {
        _txtMinute.text = "0" + GameManager.Instance.ConvertedTime.Minutes.ToString();
        _txtSeconds.text = GameManager.Instance.ConvertedTime.Seconds.ToString();
    }

    private void UpdateSheepCountUI()
    {
        _txtSheepCount.text = GameManager.Instance.CountSheep.ToString();
    }
}
