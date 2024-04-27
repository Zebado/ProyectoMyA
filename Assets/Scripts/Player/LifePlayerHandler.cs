using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayerHandler : MonoBehaviour
{
    float _lifemax = 100;
    [SerializeField]float _currentLife;
    public bool _onDead { get; private set; }

    private void OnEnable()
    {
        DamageHandler.damage += SubstractLife;
    }

    private void Awake()
    {
        _currentLife = _lifemax;
        _onDead = false;
    }
    private void SubstractLife(float damage)
    {
        _currentLife -= damage;
        if(_currentLife <= 0)
        {
            Ondead();
        }
    }
    public void Ondead()
    {
        _onDead = true;
    }
    private void OnDisable()
    {
        DamageHandler.damage -= SubstractLife;
    }
}
