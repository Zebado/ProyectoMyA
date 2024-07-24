using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, Enemy
{
    [SerializeField] int _healt;
    [SerializeField] float _speed;
    protected EnemyAnimator _enemyAnimatior;

    private void Awake()
    {
        _enemyAnimatior = GetComponent<EnemyAnimator>();
    }
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

    internal void MoveTowards(Vector2 target)
    {
        throw new NotImplementedException();
    }

    protected virtual void Death()
    {
        _enemyAnimatior.DeathAnimation();
        Destroy(gameObject);
    }
}
