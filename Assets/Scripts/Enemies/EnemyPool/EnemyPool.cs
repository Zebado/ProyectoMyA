using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyPool : Pool<EnemyBase>
{
    public EnemyPool(Func<EnemyBase> factoryMethod, Action<EnemyBase> turnOnCallback, Action<EnemyBase> turnOffCallback, int initialAmount)
        : base(factoryMethod, turnOnCallback, turnOffCallback, initialAmount)
    {
    }
}
