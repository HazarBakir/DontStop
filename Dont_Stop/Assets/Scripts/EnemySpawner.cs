using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Collider spawnArea;

    private void Start()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z));

        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }
}
