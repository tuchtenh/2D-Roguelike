using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField]
    private GameObject skeletonPrefab;

    [SerializeField]
    private float skeletonInterval = 15f;

    [SerializeField]
    public int maxEnemies = 5;

    private int enemiesSpawned = 0;

    void Start()
    {
        StartCoroutine(spawnEnemy(skeletonInterval, skeletonPrefab));
    }


    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        if(enemiesSpawned < maxEnemies)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-4f, 4), Random.Range(-4f, 10f), 0), Quaternion.identity);
            enemiesSpawned++;
        }
        
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}



