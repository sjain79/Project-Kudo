using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] platformPrefabs;

    [SerializeField]
    GameObject cloudPrefab, wingMan, coin, bubble, rocketPlatform;

    [SerializeField]
    float screenWidth;

    [SerializeField]
    float spawnMinY, spawnMaxY;

    [SerializeField]
    int maxNumberOfPlatforms;

    public static int numberOfPlatforms = 0;

    [SerializeField]
    float lastPlatformY = -3.08f;

    int maxTypeOfPlatform = 9;

    static float score;

    Vector2 startPosition;

    GameObject player;

    float previousScore = 0;

    [SerializeField]
    GameObject lastGameObjectSpawned;

    bool increaseMinSpawn;

    float enemySpawnerFrequency=2.7f;
    float powerUpSpawnerFrequency = 2.7f;
    private void Start()
    {
        for (int i = numberOfPlatforms; i < maxNumberOfPlatforms; ++i)
        {
            SpawnPlatform();
        }

        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = player.transform.position;

        InvokeRepeating("SpawnCoins", 1, 1);
        InvokeRepeating("SpawnEnemy", enemySpawnerFrequency, enemySpawnerFrequency);
        InvokeRepeating("SpawnPowerUp", powerUpSpawnerFrequency, powerUpSpawnerFrequency);
    }

    private void Update()
    {
        if (numberOfPlatforms < maxNumberOfPlatforms)
        {
            SpawnPlatform();
        }

        if (score < (player.transform.position.y - startPosition.y) * 10)
        {
            score = (player.transform.position.y - startPosition.y);
            score *= 10;
        }        
    }

    private void SpawnPlatform()
    {
        int platformType = 0;

        switch (Random.Range(0, 11))
        {
            case 0:
            case 1:
            case 2:
                platformType = 0;
                break;
            case 3:
            case 4:
            case 5: 
                platformType = 1;
                break;
            case 6:
            case 7:
            case 8:
                platformType = 2;
                break;
            case 9:
                platformType = 3;
                break;
            case 10:
                {
                    if (Random.value > 0.5f)
                    {
                        platformType = 4;
                    }
                    else
                    {
                        platformType = 1;
                    }
                    break;
                }

        }



        lastGameObjectSpawned = Instantiate(platformPrefabs[platformType], new Vector2(Random.Range(-screenWidth, screenWidth), lastGameObjectSpawned.transform.position.y + Random.Range(spawnMinY, spawnMaxY)), Quaternion.identity);

        numberOfPlatforms++;
    }


    private void SpawnCoins()
    {
        lastGameObjectSpawned= Instantiate(coin, new Vector2(Random.Range(-screenWidth, screenWidth), lastGameObjectSpawned.transform.position.y + 0.35f), Quaternion.identity);
    }

    private void SpawnEnemy()
    {
        if (Random.value>0.5)
        { 
            lastGameObjectSpawned = Instantiate(cloudPrefab, new Vector2(Random.Range(-screenWidth, screenWidth), lastGameObjectSpawned.transform.position.y + Random.Range(1.8f, 2.2f)), Quaternion.identity);
        }
        else
        {
            lastGameObjectSpawned = Instantiate(wingMan, new Vector2(Random.Range(-screenWidth, screenWidth), lastGameObjectSpawned.transform.position.y + Random.Range (1.8f,2.2f)), Quaternion.identity);
        }
    }

    private void SpawnPowerUp()
    {
        if (Random.value > 0.5)
        {
            lastGameObjectSpawned = Instantiate(rocketPlatform, new Vector2(Random.Range(-screenWidth, screenWidth), lastGameObjectSpawned.transform.position.y + Random.Range(0.1f, 0.3f)), Quaternion.identity);
            increaseMinSpawn = true;
        }
        else
        {
            lastGameObjectSpawned = Instantiate(bubble, new Vector2(Random.Range(-screenWidth, screenWidth), lastGameObjectSpawned.transform.position.y + Random.Range(00.1f, 0.3f)), Quaternion.identity);
        }
    }

    private void IncreaseDifficulty()
    {
        if (score >= 30 && score % 30 == 0 && enemySpawnerFrequency > 1.2f)
        {
            enemySpawnerFrequency -= 0.15f;
        }

        if (score >=40 && score%40==0 && powerUpSpawnerFrequency>1.4f)
        {
            powerUpSpawnerFrequency -= 0.15f;
        }

        if (score >=28 && score %28==0 && spawnMinY<1)
        {
            spawnMinY += 0.1f;
        }

        if ((score >= 32 && score % 32 == 0 && spawnMinY < 1.8))
        {
            spawnMaxY += 0.1f;
        }
        
    }

}
