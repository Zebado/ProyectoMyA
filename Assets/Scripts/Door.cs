using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool _win;

    private void OnEnable()
    {
        _win = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_win) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            _win = true;
            EventManager.TriggerEvent(EventsType.Event_Win);
        }
    }
}
