using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private EnemyBase meleeEnemyPrefab;
    [SerializeField] private EnemyBase rangeEnemyPrefab;

    public EnemyBase CreateMeleeEnemy()
    {
        return Instantiate(meleeEnemyPrefab);
    }

    public EnemyBase CreateRangeEnemy()
    {
        return Instantiate(rangeEnemyPrefab);
    }
}
