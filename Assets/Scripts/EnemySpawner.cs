using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> _enemies;
    [SerializeField] Transform[] _spawnPoint;
    [SerializeField] List<Transform> _patrolPoints;
    [SerializeField] float _spawnDelay = 0.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PMovementController player = collision.GetComponent<PMovementController>();
        if (player != null)
            StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()  //timeslicing de spawn de enemigos y linq grupos
    {
        if (_enemies.Count == 0 || _spawnPoint.Length == 0) yield break;
        //Take and ToList, usamos el take para agarrar los puntos de spawn segun la cantidad de enemigos a instanciar y los convertimos a una lista.
        var spawnPoints = _spawnPoint.Take(_enemies.Count).ToList();

        //igualamos los enemigos a los puntos a spawnear, para que tengan la referencia de donde instanciarse.
        var enemiesSpawnPoints = _enemies.Zip(spawnPoints, (Enemy, spawnPoint) => new { Enemy = Enemy, spawnPoint = spawnPoint });

        int patrolIndex = 0;

        foreach (var pair in enemiesSpawnPoints)
        {
            GameObject enemyInstance = Instantiate(pair.Enemy, pair.spawnPoint.position, pair.spawnPoint.rotation);
            EnemyMelee meleeEnemy = enemyInstance.GetComponent<EnemyMelee>();

            if (meleeEnemy != null && patrolIndex + 1 < _patrolPoints.Count)
            {
                //buscamos los puntos, los asignamos y luego los convierot en lista
                var patrolList = _patrolPoints.Skip(patrolIndex).Take(2).ToList();
                meleeEnemy.SetPatrolPoints(patrolList[0], patrolList[1]);

                patrolIndex += 2;
            }
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PMovementController player = collision.GetComponent<PMovementController>();
        if (player != null)
            gameObject.SetActive(false);

    }
}
