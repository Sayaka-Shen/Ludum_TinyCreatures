using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _door;

    private bool _isCloseToDoor = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.KeyCount >= 1 && _isCloseToDoor)
        {
            Destroy(_door);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out HeroControls heroControls))
        {
            _isCloseToDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out HeroControls heroControls))
        {
            _isCloseToDoor = false;
        }
    }
}
