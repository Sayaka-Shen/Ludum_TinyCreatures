using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance {  get { return _instance; } }
    
    [SerializeField] private int _countSheep;

    public int CountSheep
    {
        get { return _countSheep; }
        set { _countSheep = value; }
    }
    
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
}
