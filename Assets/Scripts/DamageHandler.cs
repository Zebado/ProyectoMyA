using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageHandler : MonoBehaviour
{
    public delegate void DetectDamage(float damage);
    public static event DetectDamage damage;

    [SerializeField] float _damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            damage?.Invoke(_damage);
        }
    }
}
