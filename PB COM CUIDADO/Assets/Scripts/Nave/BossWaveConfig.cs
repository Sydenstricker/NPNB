using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss Wave Config")]

public class BossWaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetBossWaypoints()
    {
        var bossWaveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            bossWaveWaypoints.Add(child);
        }
        return bossWaveWaypoints;

    }
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }
    public float GetMoveSpeed() { return moveSpeed; }
}