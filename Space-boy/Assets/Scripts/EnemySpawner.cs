using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField] private GameObject Enemy;

    [Header("Spawner")]
    [SerializeField] private float spawnTime = 3;
    [SerializeField] private int spawnAmount = 3;

    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            spawnTime = 3;

            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject newEnemy = Instantiate(Enemy, transform.position + new Vector3(spawnAmount / 2 * 2 + i * 2, 0, 0), Quaternion.identity);

            }
        }
    }
}
