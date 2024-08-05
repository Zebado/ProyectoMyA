using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    [SerializeField] private EnemyFactory enemyFactory;
    private EnemyPool meleeEnemyPool;
    private EnemyPool rangeEnemyPool;

    [SerializeField]List<GameObject> _spawnPoints;
    int _spawnPointIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializePools();
    }

    private void InitializePools()
    {
        meleeEnemyPool = new EnemyPool(
            enemyFactory.CreateMeleeEnemy,
            OnEnemySpawned,
            OnEnemyDespawned,
            5
        );

        rangeEnemyPool = new EnemyPool(
            enemyFactory.CreateRangeEnemy,
            OnEnemySpawned,
            OnEnemyDespawned,
            5
        );
    }
    private void OnEnemySpawned(EnemyBase enemy)
    {
        enemy.gameObject.SetActive(true);
    }

    private void OnEnemyDespawned(EnemyBase enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    public EnemyBase SpawnMeleeEnemy(Vector2 position)
    {
        EnemyBase enemy = meleeEnemyPool.GetObject();
        Transform spawnPoint = GetSpawnPoint();
        enemy.transform.position = spawnPoint.position;
        return enemy;
    }

    public EnemyBase SpawnRangeEnemy(Vector2 position)
    {
        EnemyBase enemy = rangeEnemyPool.GetObject();
        Transform spawnPoint = GetSpawnPoint();
        enemy.transform.position = spawnPoint.position;
        return enemy;
    }
    private Transform GetSpawnPoint()
    {
        Transform spawnPoint = _spawnPoints[_spawnPointIndex].transform;
        _spawnPointIndex++;
        return spawnPoint;
    }
    public void DespawnEnemy(EnemyBase enemy)
    {
        if (enemy is EnemyMelee)
        {
            meleeEnemyPool.ReturnObjectToPool(enemy);
        }
        else if (enemy is RangeEnemy)
        {
            rangeEnemyPool.ReturnObjectToPool(enemy);
        }
    }
}
