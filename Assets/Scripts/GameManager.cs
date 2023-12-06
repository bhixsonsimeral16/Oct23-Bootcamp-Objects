using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float enemySpawnRate = 5f;
    [SerializeField] int maxEnemyCount = 10;

    GameObject tempEnemy;
    bool isEnemySpawning;
    Weapon meleeWeapon = new Weapon("Melee", 1f, 0f);
    public int enemyCount = 0;
    public static GameManager instance;

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
    void Start()
    {
        isEnemySpawning = true;
        StartCoroutine(SpawnEnemy());
    }

    void CreateEnemy()
    {
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
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
}
