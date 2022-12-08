using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnLogic
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private List<SpawnPoint> _spawnPointsList = new List<SpawnPoint>();
        [SerializeField] private float _spawnTimePause = 2f;
        
        private void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            int currentSpawnPointIndex = 0;
            var pauseWait = new WaitForSeconds(_spawnTimePause);

            while (true)
            {
                Instantiate<Enemy>(_enemyPrefab, _spawnPointsList[currentSpawnPointIndex].transform.position, Quaternion.identity);

                yield return pauseWait;

                currentSpawnPointIndex = (currentSpawnPointIndex + 1) % _spawnPointsList.Count;

            }
        }        
    }
}
