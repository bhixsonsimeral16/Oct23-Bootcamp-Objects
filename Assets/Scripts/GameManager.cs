using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float enemySpawnRate = 5f;
    [SerializeField] int maxEnemyCount = 10;
    [SerializeField] GameObject playerPrefab;

    [HideInInspector] public int enemyCount = 0;
    [HideInInspector] public bool isEnemySpawning;

    GameObject tempEnemy;
    Weapon meleeWeapon = new Weapon("Melee", 1f, 0f);
    Player player;
    bool isPlaying = false;

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

    // Start is called before the first frame update
    // void Start()
    // {
    //     FindPlayer();
    //     isEnemySpawning = true;
    //     StartCoroutine(SpawnEnemy());
    // }

    void CreateEnemy()
    {
        int randomSpawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
        tempEnemy = Instantiate(enemyPrefab, spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);
        tempEnemy.GetComponent<Enemy>().weapon = meleeWeapon;
        tempEnemy.GetComponent<MeleeEnemy>().SetMeleeEnemy(2f, 0.25f);
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
