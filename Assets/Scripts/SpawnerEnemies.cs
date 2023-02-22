using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] Transform groundSize;
    [SerializeField] GameObject simpleEnemy;
    [SerializeField] float spawnTimer = 1;
    [SerializeField] private float spawnRadius = 10.0f;
    [SerializeField] private float spawnInterval = 2.0f;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnTimer, simpleEnemy));
    }

    void Update()
    {
    }


    private IEnumerator spawnEnemy(float timer, GameObject enemy)
    {
        while (true)
        {
            Vector3 randomPos = mainCamera.transform.position + Random.insideUnitSphere * spawnRadius;
            randomPos.y = 0;

            Instantiate(simpleEnemy, randomPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);

            /* float height = mainCamera.orthographicSize + 1;
            float width = mainCamera.aspect + 1;
            float randX = mainCamera.transform.position.x + Random.Range(-width, width);
            float randZ = mainCamera.transform.position.z + height + Random.Range(10, 30);
            */
            //  yield return new WaitForSeconds(spawnTimer);
            //     float x = Random.Range(-groundSize.localScale.x, groundSize.localScale.x);
            //   float z = Random.Range(-groundSize.localScale.z, groundSize.localScale.z);

            // GameObject newEnemy = Instantiate(enemy, new Vector3(randX, 1, randZ), Quaternion.identity);
            //  StartCoroutine(spawnEnemy(timer, enemy));
        }
    }
}

