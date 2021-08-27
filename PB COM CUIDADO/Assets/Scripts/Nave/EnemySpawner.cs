using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfig;
    [SerializeField] List<BossConfig> bossConfig;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool isEndless = false;
    [SerializeField] int ptsSpawnBoss = 5;
    private bool spawnoBoss = false;
    GameObject enemyParent;
    const string ENEMY_PARENT_NAME = "Enemy";
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        CreateEnemyParent();        
        //GetComponent<Player>().pontosIDcoletados;
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (isEndless);
    }

    

    private void CreateEnemyParent()
    {
        enemyParent = GameObject.Find(ENEMY_PARENT_NAME);
        if (! enemyParent)
        {
            enemyParent = new GameObject(ENEMY_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (FindObjectOfType<Player>() == null) {return;}

        if (spawnoBoss == false && FindObjectOfType<Player>().pontosIDcoletados >= ptsSpawnBoss)
        {
            InvocaBigBoneco();
        }
        
    }

    private void InvocaBigBoneco()
    {
        isEndless = false;
        StopAllCoroutines();
        StartCoroutine(SpawnBossWave());
        spawnoBoss = true;
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
            newEnemy.transform.parent = enemyParent.transform;
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
    private IEnumerator SpawnBossWave()
    {
        for (int bossIndex = startingWave; bossIndex < bossConfig.Count; bossIndex++)
        {
            var bossWave = bossConfig[bossIndex];
            yield return StartCoroutine(SpawnBossEnemieInWave(bossWave));

        }
    }
    private IEnumerator SpawnBossEnemieInWave(BossConfig bossConfig)
    {
        for (int enemyCount = 0; enemyCount < bossConfig.GetNumberOfEnemies(); enemyCount++)
        {
             var newEnemy = Instantiate (
             bossConfig.GetEnemyPrefab(),
             bossConfig.GetWaypoints()[0].transform.position,
             Quaternion.identity);
            newEnemy.GetComponent<BossPathing>().SetBossConfig(bossConfig);
            yield return new WaitForSeconds(bossConfig.GetTimeBetweenSpawns());
        }
    }
}


