using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] int _damage = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            EventManager.TriggerEvent(EventsType.Event_SubstractLife, _damage);
        }
    }
}
