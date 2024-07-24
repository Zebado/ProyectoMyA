using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyBase
{
    public override void Attack()
    {
        _enemyAnimatior.AttackAnimation();
    }

    public override void Move()
    {
       
    }
}
