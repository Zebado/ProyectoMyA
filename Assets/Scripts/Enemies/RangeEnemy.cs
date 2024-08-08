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
        enemyState.Update();
    }
    public override void Attack()
    {
        _enemyAnimatior.AttackAnimation();
    }
    public void CreateArrow()
    {
        var bullet = BulletFactory.Instance.GetObjectFromPool(EnumBullet.ArrowBullet);
        bullet.transform.position = _point.transform.position;
    }
}
