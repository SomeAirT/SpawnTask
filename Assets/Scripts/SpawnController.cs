using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnLogic
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private GameObject spawnObjectPrefab;
        [SerializeField] private List<Transform> spawnPointsList = new List<Transform>();
        [SerializeField] private float spawnTimePause = 2f;
        
        private void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            int currentSpawnPointIndex = 0;
            var pauseWait = new WaitForSeconds(spawnTimePause);

            while (true)
            {
                Instantiate(spawnObjectPrefab, spawnPointsList[currentSpawnPointIndex].position, Quaternion.identity);

                yield return pauseWait;

                currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnPointsList.Count;

            }
        }

        
    }
}
