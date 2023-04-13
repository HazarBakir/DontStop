using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnStates { SPAWNING, WAITING, COUNTING }

    [System.Serializable]
    public class Wave
    {

        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave;
    public Transform[] spawnPoints; 
    public int timeBetweenWaves = 5;
    public float waveCountDown;
    private float searchCountDown = 1;
    public SpawnStates state = SpawnStates.COUNTING;

    private void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    private void Update()
    {
        if (EnemyisAlive())
        {
            return;
        }

        // Geri sayımı başlatın
        if (state == SpawnStates.COUNTING)
        {
            waveCountDown -= Time.timeScale;
            if (waveCountDown <= 0)
            {
                // Dalga spawn işlemini başlatın
                if (state != SpawnStates.SPAWNING)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
        }
    }


    void BeginNewRound()
    {
        state = SpawnStates.COUNTING;
        waveCountDown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length - 1)
        {
            // if you want no more waves when waves finished.
            // state = SpawnStates.WAITING;

            nextWave = 0;
            Debug.Log("Completed All Rounds!");
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyisAlive()
    {
        searchCountDown -= Time.deltaTime;
        if(searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {

        state = SpawnStates.SPAWNING;
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        state = SpawnStates.WAITING;
        while (EnemyisAlive())
        {
            yield return null;
        }
        BeginNewRound();
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
