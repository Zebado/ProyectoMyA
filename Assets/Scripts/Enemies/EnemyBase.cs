using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, Enemy
{
    [SerializeField] int _healt;
    [SerializeField] float _speed;
    protected EnemyAnimator _enemyAnimatior;
    public Transform targetPlayer;
    public float attackRange;
    public EnemyState enemyState;

    private void Awake()
    {
        _enemyAnimatior = GetComponent<EnemyAnimator>();
    }
    public abstract void Attack();

    public void TakeDamage(int damage)
    {
        _healt -= damage;
        if (_healt <= 0)
        {
            Death();
        }
    }
    public Vector2 PlayerPosition()
    {
        if (targetPlayer != null)
        {
            return targetPlayer.position;
        }

        return Vector2.zero;
    }
    internal void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
        _enemyAnimatior.WalkAnimation();
    }
    public bool IsPlayerInRange(float distance)
    {
        if (targetPlayer == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                targetPlayer = player.transform;
            }
        }
        if (targetPlayer != null)
        {
            return Vector2.Distance(transform.position, targetPlayer.position) <= distance;
        }
        return false;
    }
    protected virtual void Death()
    {
        _enemyAnimatior.DeathAnimation();
        Destroy(gameObject);
    }
}
