using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float enemySpawnRate = 5f;
    [SerializeField] int maxEnemyCount = 10;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] EnemySpawn[] enemyPrefabs;


    [HideInInspector] public int enemyCount = 0;
    [HideInInspector] public bool isEnemySpawning;

    GameObject tempEnemy;
    Player player;
    bool isPlaying = false;
    List<Enemy> enemyPool = new List<Enemy>();

    public Action OnGameStart;
    public Action OnGameEnd;

    public static GameManager instance;
    public ScoreManager scoreManager;
    public PickupSpawner pickupSpawner;

    public static GameManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            for (int j = 0; j < enemyPrefabs[i].spawnWeight; j++)
            {
                enemyPool.Add(enemyPrefabs[i].enemy);
            }
        }
    }

    void CreateEnemy()
    {
        int randomSpawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
        Enemy randomEnemy = enemyPool[UnityEngine.Random.Range(0, enemyPool.Count)];
        tempEnemy = Instantiate(randomEnemy.gameObject, spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            CreateEnemy();
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(isEnemySpawning)
        {
            if (enemyCount < maxEnemyCount)
            {
                yield return new WaitForSeconds(1f/enemySpawnRate);
                CreateEnemy();
                enemyCount++;
            }
            else
            {
                yield return null;
            }
        }
    }

    public void NotifyEnemyDeath(Enemy enemy)
    {
        pickupSpawner.SpawnPickup(enemy.transform.position);
        enemyCount--;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }

    public void StartGame()
    {
        player = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity).GetComponent<Player>();
        player.OnDeath += StopGame;
        isPlaying = true;
        
        OnGameStart?.Invoke();
        StartCoroutine(GameStarter());
    }

    IEnumerator GameStarter()
    {
        yield return new WaitForSeconds(2.0f);
        isEnemySpawning = true;
        StartCoroutine(SpawnEnemy());
    }

    public void StopGame()
    {
        scoreManager.SetHighScore();
        StartCoroutine(GameStopper());
    }

    IEnumerator GameStopper()
    {
        isEnemySpawning = false;
        yield return new WaitForSeconds(2.0f);
        isPlaying = false;

        // Delete all enemies
        foreach (Enemy enemy in FindObjectsOfType(typeof(Enemy)))
        {
            Destroy(enemy.gameObject);
            enemyCount--;
        }

        // Delete all pickups
        foreach (Pickup pickup in FindObjectsOfType(typeof(Pickup)))
        {
            Destroy(pickup.gameObject);
        }

        // Delete all bullets
        foreach (Bullet bullet in FindObjectsOfType(typeof(Bullet)))
        {
            Destroy(bullet.gameObject);
        }

        OnGameEnd?.Invoke();
    }

    // public void FindPlayer()
    // {
    //     try
    //     {
    //         player = GameObject.FindWithTag("Player").GetComponent<Player>();
    //     }
    //     catch(NullReferenceException e)
    //     {
    //         Debug.Log("The player could not be found." + e.Message);
    //     }
    // }
}

[System.Serializable]

public struct EnemySpawn
{
    public Enemy enemy;
    public int spawnWeight;
}
