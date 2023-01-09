using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnLogic
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private List<SpawnPoint> _spawnPointsList = new List<SpawnPoint>();
        [SerializeField] private float _delay = 2f;
        
        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            int currentSpawnPointIndex = 0;
            var pauseWait = new WaitForSeconds(_delay);

            while (true)
            {
                Instantiate<Enemy>(_prefab, _spawnPointsList[currentSpawnPointIndex].transform.position, Quaternion.identity);

                yield return pauseWait;

                currentSpawnPointIndex = (currentSpawnPointIndex + 1) % _spawnPointsList.Count;

            }
        }        
    }
}
