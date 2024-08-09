using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : EnemyBase
{
    [SerializeField] Transform _point;
    private void Start()
    {
        enemyState = new EnemyState();
        enemyState.ChangeState(new IdleState(), this);
    }
    private void Update()
    {
        if (!isDead)
        {
            enemyState.Update();

            if (targetPlayer != null && IsPlayerInRange(attackRange))
            {
                FacePlayer();
            }
        }
    }
    public override void Attack()
    {
        if (!isDead)
            _enemyAnimatior.AttackAnimation();
    }
    public void CreateArrow()
    {
        var bullet = BulletFactory.Instance.GetObjectFromPool(EnumBullet.ArrowBullet);
        bullet.transform.position = _point.transform.position;

        Vector2 direction = (targetPlayer.position - transform.position).normalized;
        direction.y = 0;
        bullet.GetComponent<Bullet>().SetDirection(direction);
        if (direction.x < 0)
        {
            bullet.transform.localScale = new Vector3(-Mathf.Abs(bullet.transform.localScale.x), bullet.transform.localScale.y, bullet.transform.localScale.z);
        }
        else
        {
            bullet.transform.localScale = new Vector3(Mathf.Abs(bullet.transform.localScale.x), bullet.transform.localScale.y, bullet.transform.localScale.z);
        }
    }
}
