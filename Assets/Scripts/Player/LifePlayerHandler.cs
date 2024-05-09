using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayerHandler : MonoBehaviour
{
    int _lifemax = 3;
    [SerializeField]int _currentLife;
    public bool _onDead { get; private set; }

    private void OnEnable()
    {
        DamageHandler.damage += SubstractLife;
        Posion.addlife += RecoverLife;
    }

    private void Awake()
    {
        _currentLife = _lifemax;
        _onDead = false;
    }
    private void SubstractLife(int damage)
    {
        _currentLife -= damage > 1 ? damage : 1;
        if(_currentLife <= 0)
        {
            Ondead();
        }
    }
    private void RecoverLife()
    {
        _currentLife += 1;
    }
    public void Ondead()
    {
        _onDead = true;
    }
    private void OnDisable()
    {
        DamageHandler.damage -= SubstractLife;
        Posion.addlife -= RecoverLife;

    }
}
