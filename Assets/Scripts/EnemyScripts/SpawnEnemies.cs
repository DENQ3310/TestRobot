using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f; // интервал между появлением врагов
    public int maxEnemies = 10; // максимальное количество врагов

    private int currentEnemies = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (currentEnemies < maxEnemies)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition(); // получаем случайное местоположение для появления врага
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                currentEnemies++;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Collider collider = GetComponent<Collider>(); // получаем коллайдер

        Vector3 bounds = collider.bounds.size;
        float x = Random.Range(-bounds.x / 2, bounds.x / 2);
        float z = Random.Range(-bounds.z / 2, bounds.z / 2);

        return transform.position + new Vector3(x, 0, z);
    }
}
