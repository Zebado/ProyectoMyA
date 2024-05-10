using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posion : MonoBehaviour
{
    public delegate void AddLife();
    public static event AddLife addlife;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && LifePlayerHandler._currentLife < LifePlayerHandler._lifemax)
        {
            addlife?.Invoke();
            OnDestroy();
        }
    }
    private void OnDestroy()
    {
        Destroy(gameObject);    
    }
}
