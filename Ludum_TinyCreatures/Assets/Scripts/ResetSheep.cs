using System;
using UnityEngine;

public class ResetSheep : MonoBehaviour
{
    [SerializeField] private PushObject _pushObject;
    private Rigidbody2D _massiveObjectRigidbody;

    private void Awake()
    {
        _massiveObjectRigidbody = _pushObject.gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out HeroControls heroControls))
            return;
        
        GameManager.Instance.CountSheep -= _pushObject.SheepNecessary;

        _massiveObjectRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
