using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out HeroControls heroControls))
        {
            GameManager.Instance.GameState = GameState.EndGame;
        }
    }
}
