using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, Enemy
{
    [SerializeField] int _healt;
    [SerializeField] float _speed;
    public abstract void Attack();

    public abstract void Move();

    public void TakeDamage(int damage)
    {
        _healt -= damage;
        if(_healt <= 0)
        {
            Death();
        }
    }
    protected virtual void Death()
    {

    }
}
