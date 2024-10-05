using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    private Rigidbody2D _objectRigidbody;

    [SerializeField] private int _sheepNecessary;

    private void Awake()
    {
        _objectRigidbody = GetComponent<Rigidbody2D>();

        _objectRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void Update()
    {
        if (GameManager.Instance.CountSheep >= _sheepNecessary)
        {
            _objectRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
