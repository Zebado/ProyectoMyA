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
    public float chaseRange;
    public EnemyState enemyState;
    Rigidbody2D _rg2d;
    public bool isDead { get; private set; }

    private void Awake()
    {
        _enemyAnimatior = GetComponent<EnemyAnimator>();
        _rg2d = GetComponent<Rigidbody2D>();
        if (enemyState == null)
        {
            enemyState = new EnemyState();
        }
    }
    public abstract void Attack();

    public void TakeDamage(int damage)
    {
        if (isDead) return;
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
        if (isDead) return;
        Vector2 direction = new Vector2(target.x - transform.position.x, 0);
        _rg2d.velocity = new Vector2(direction.x * _speed, _rg2d.velocity.y).normalized;
        _enemyAnimatior.WalkAnimation();

        FaceDirection(direction);
    }
    internal void FacePlayer()
    {
        if (targetPlayer != null)
        {
            Vector2 direction = targetPlayer.position - transform.position;
            FaceDirection(direction);
        }
    }

    private void FaceDirection(Vector2 direction)
    {
        if (direction.x > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (direction.x < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
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
            return Mathf.Abs(transform.position.x - targetPlayer.position.x) <= distance;
        }
        return false;
    }
    protected virtual void Death()
    {
        if (isDead) return;
        isDead = true;
        _enemyAnimatior.DeathAnimation();
    }
    public void DestroyEnemi()
    {
        Destroy(gameObject);

    }
}
