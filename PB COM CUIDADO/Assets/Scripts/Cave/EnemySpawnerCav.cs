using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawnerCav : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfig;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool isEndless = false;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        //GetComponent<Player>().pontosIDcoletados;
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (isEndless);
    }
   
    
    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfig.Count; waveIndex++)
        {
            var currentWave = waveConfig[waveIndex];
            yield return StartCoroutine(SpawnAllEnemieInWave(currentWave));

        }
    }
    private IEnumerator SpawnAllEnemieInWave(WaveConfig waveConfig)
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


