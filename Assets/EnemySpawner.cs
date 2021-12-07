using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float time = 1.5f;
    [SerializeField] private int numberOfEnemies = 3;
    [SerializeField] public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-20f, 20f), Random.Range(-12f, 12f));
            Instantiate(spawn, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.12f);
        }
        numberOfEnemies += 2;
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnEnemy());
    }
}
