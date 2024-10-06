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
        if (_door.CompareTag("Door") && Input.GetKeyDown(KeyCode.E) && GameManager.Instance.KeyCount >= 1 && _isCloseToDoor)
        {
            Destroy(_door);
            AudioManager.Instance.PlaySound(SoundClip.Door, Sources.Level);
        } else if (_door.CompareTag("SecretDoor") && Input.GetKeyDown(KeyCode.E) && GameManager.Instance.KeySecretDoorCount >= 1 && _isCloseToDoor)
        {
            Destroy(_door);
            AudioManager.Instance.PlaySound(SoundClip.Door, Sources.Level);
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
