using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> _enemies;
    [SerializeField] Transform[] _spawnPoint;
    [SerializeField] List<Transform> _patrolPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PMovementController player = collision.GetComponent<PMovementController>();
        if (player != null)
            SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (_enemies.Count == 0 || _spawnPoint.Length == 0) return;

        for (int i = 0; i < _enemies.Count; i++)
        {
            GameObject enemyInstance = Instantiate(_enemies[i], _spawnPoint[i].position, _spawnPoint[i].rotation);
            EnemyMelee meleeEnemy = enemyInstance.GetComponent<EnemyMelee>();

            if (meleeEnemy != null && _patrolPoints.Count >= 2)
            {
                meleeEnemy.SetPatrolPoints(_patrolPoints[0], _patrolPoints[1]);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PMovementController player = collision.GetComponent<PMovementController>();
        if (player != null)
        {
            gameObject.SetActive(false);
        }
    }
}
