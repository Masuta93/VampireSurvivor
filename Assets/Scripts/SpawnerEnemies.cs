using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] Transform groundSize;
    [SerializeField] GameObject simpleEnemy;
    [SerializeField] float spawnTimer = 1; 

    void Start()
    {
        StartCoroutine(spawnEnemy(spawnTimer, simpleEnemy));
    }

    void Update()
    {
    }


    private IEnumerator spawnEnemy(float timer, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnTimer);
        float x = Random.Range(-groundSize.localScale.x, groundSize.localScale.x);
        float z = Random.Range(-groundSize.localScale.z, groundSize.localScale.z);

        GameObject newEnemy = Instantiate(enemy, new Vector3(x, 1, z), Quaternion.identity);
        StartCoroutine(spawnEnemy(timer, enemy));
    }
}
