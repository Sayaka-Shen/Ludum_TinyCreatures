using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushMusique : MonoBehaviour
{
    private Rigidbody2D _boxRigidbody2D;

    private bool _isMoving;
    private void Awake()
    {
        _boxRigidbody2D = GetComponent<Rigidbody2D>();
        _isMoving = false;
    }

    private void Update()
    {
        if (_boxRigidbody2D.velocity != Vector2.zero && !_isMoving)
        {
            _isMoving = true;
            AudioManager.Instance.PlaySound(SoundClip.Push, Sources.Push);
        }else if (_boxRigidbody2D.velocity == Vector2.zero && _isMoving)
        {
            _isMoving = false;
            AudioManager.Instance.StopSound(Sources.Push);
        }
    }
}
