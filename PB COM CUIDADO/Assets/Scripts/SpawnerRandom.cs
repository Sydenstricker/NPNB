using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] List<WaveConfig> waveConfig;
    //[SerializeField] bool isEndless = false;
    [SerializeField] int startingWave = 0;
    [SerializeField] float minDelay = 0f, maxDelay = 5f;
    [SerializeField] GameObject inimigo;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn) 
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            SpawnInimigo();
        }
        
    }
    private void SpawnInimigo()
    {
        Instantiate(inimigo, transform.position, transform.rotation);
    }

    private IEnumerator SpawnRandom()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfig.Count; waveIndex++)
        {
            var currentWave = waveConfig[waveIndex];
            yield return StartCoroutine(SpawnWaves(currentWave));
        }
    }
    private IEnumerator SpawnWaves(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
             waveConfig.GetEnemyPrefab(),
             waveConfig.GetWaypoints()[0].transform.position,
             Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
