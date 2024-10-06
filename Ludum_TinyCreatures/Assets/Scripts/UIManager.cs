using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get { return _instance; }
    }
    
    [Header("Timer")]
    [SerializeField] private RectTransform _timerGameObject;

    public RectTransform TimerGameObject
    {
        get { return _timerGameObject; }
    }
    
    [SerializeField] private TextMeshProUGUI _txtMinute;
    [SerializeField] private TextMeshProUGUI _txtSeconds;
    [SerializeField] private TextMeshProUGUI _txtPointTimer;
    
    [Header("TimerSlidePosition")]
    [SerializeField] private Transform _timerIn;
    [SerializeField] private Transform _timerOut;
    [SerializeField] private float _slideDuration;
    [SerializeField] private float _fadeDuration;
    
    [Header("Sheep")] 
    [SerializeField] private TextMeshProUGUI _txtSheepCount;

    [Header("Menu")] 
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _mainScreen;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _loseScreen;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
    
    private void Update()
    {
        UpdateTimerUI();
        UpdateSheepCountUI();
    }


    private void UpdateTimerUI()
    {
        if(GameManager.Instance.ConvertedTime.Minutes < 10)
            _txtMinute.text = "0" + GameManager.Instance.ConvertedTime.Minutes.ToString();
        else
            _txtMinute.text = GameManager.Instance.ConvertedTime.Minutes.ToString();
        if(GameManager.Instance.ConvertedTime.Seconds < 10)
            _txtSeconds.text = "0" + GameManager.Instance.ConvertedTime.Seconds.ToString();
        else
            _txtSeconds.text = GameManager.Instance.ConvertedTime.Seconds.ToString();
    }

    private void UpdateSheepCountUI()
    {
        _txtSheepCount.text = GameManager.Instance.CountSheep.ToString();
    }

    public void Slide(string inOrOut)
    {
        switch (inOrOut)
        {
            case("in"):
                _timerGameObject.transform.position = _timerOut.position;
                StartCoroutine(StartDoFade(100f, 0));
                break;
            case("out"):
                GameManager.Instance.LetPlayerMove = false;
                StartCoroutine(WaitForSlideOut(2));
                StartCoroutine(StartDoFade(0, _slideDuration * 2));
                break;
        }
    }

    IEnumerator StartDoFade(float endValue, float waitDuration)
    {
        yield return new WaitForSeconds(waitDuration);
        _txtMinute.DOFade(endValue, _fadeDuration);
        _txtSeconds.DOFade(endValue, _fadeDuration);
        _txtPointTimer.DOFade(endValue, _fadeDuration);
        GameManager.Instance.LetPlayerMove = true;
    }

    IEnumerator WaitForSlideOut(float waitDuration)
    {
        yield return new WaitForSeconds(waitDuration);
        _timerGameObject.DOMove(_timerOut.position, _slideDuration);
    }

    public void UnloadUI(string uiName)
    {
        switch (uiName)
        {
            case("start"):
                _startScreen.SetActive(false);
                break;
            case("main"):
                _mainScreen.SetActive(false);
                break;
            case("end"):
                _endScreen.SetActive(false);
                break;
            case("lose"):
                _loseScreen.SetActive(false);
                break;
        }
    }
    
    public void LoadUI(string uiName)
    {
        switch (uiName)
        {
            case("start"):
                _startScreen.SetActive(true);
                break;
            case("main"):
                _mainScreen.SetActive(true);
                break;
            case("end"):
                _endScreen.SetActive(true);
                break;
            case("lose"):
                _loseScreen.SetActive(true);
                break;
        }
    }

    public void DestroyManager()
    {
        Destroy(gameObject);
    }
}
