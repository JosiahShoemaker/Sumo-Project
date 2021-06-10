using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject powerupPrefab;

    [SerializeField]
    [Tooltip("sets range of spawn")]
    float spawnRange = 9f;

    [SerializeField]
    [Tooltip("Number Of Enemies")]
     int enemyCount;

    [SerializeField]
    [Tooltip("Number of Wave")]
    int waveNumber = 1;

    [SerializeField]
    [Tooltip("Current wave of Enemies")]
    Text currentWave;
    // Start is called before the first frame update
    void Start()
    {
        // Spawns enimies and powerup
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScores();
        //When enimies equel zero new enimies spawn
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), transform.rotation);
        }
    }
    // for loop generating powerups and emimies
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    //generates random spawn position for enemy
    Vector3 GenerateSpawnPosition()
    {
        // X position spawn
        float spawnPosx = Random.Range(-spawnRange, spawnRange);
        // Z position spawn
        float spawnPosz = Random.Range(-spawnRange, spawnRange);
        // Random spawn positions
        Vector3 randomPos = new Vector3(spawnPosx, 0, spawnPosz);
        return randomPos;
    }

    private void UpdateScores()
    {
        currentWave.text = "Current Wave: " + waveNumber.ToString();
    }

}
