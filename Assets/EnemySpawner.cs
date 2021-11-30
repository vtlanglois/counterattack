using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRadius = 7, time = 1.5f;
    [SerializeField] public GameObject[] enemies;
    [SerializeField] public int enemyNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
            Vector2 spawnPosition = GameObject.Find("Player").transform.position;
            spawnPosition += Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(time);
            StartCoroutine(SpawnEnemy());
    }
}
