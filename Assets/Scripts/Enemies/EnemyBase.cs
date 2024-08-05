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
        if (enemyState == null)
        {
            enemyState = new EnemyState();
        }
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
        Vector2 direction = target - (Vector2)transform.position;
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
        _enemyAnimatior.WalkAnimation();

        if (direction.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
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
        EnemyManager.Instance.DespawnEnemy(this);
    }
}
