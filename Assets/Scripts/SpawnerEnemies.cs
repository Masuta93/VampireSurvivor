using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] Transform groundSize;
    [SerializeField] GameObject simpleEnemy;
    [SerializeField] float spawnTimer;
    [SerializeField] private float spawnRadius = 10.0f;
    [SerializeField] private float spawnInterval = 2.0f;
    [SerializeField] private Vector3 spawnArea;
    public AnimationCurve spawnRateCurve;
    private Camera mainCamera;
    float timer;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    void Start()
    {
        spawnRateCurve = new AnimationCurve();
        // StartCoroutine(spawnEnemy(spawnTimer, simpleEnemy));
    }

    void Update()
    {
        // spawnTimer = spawnRateCurve.Evaluate(Time.time);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();
        GameObject newEnemy = Instantiate(simpleEnemy);
        newEnemy.transform.position = position;

    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.z = spawnArea.z * f;
        }
        else
        {
            position.z = UnityEngine.Random.Range(-spawnArea.z, spawnArea.z);
            position.x = spawnArea.x * f;
        }

        position.y = 0;

        return position;
    }

    /* private IEnumerator spawnEnemy(float timer, GameObject enemy)
      {
          while (true)
          {
              Vector3 randomPos = mainCamera.transform.position + UnityEngine.Random.insideUnitSphere * spawnRadius;
              randomPos.y = 0;

              Instantiate(simpleEnemy, randomPos, Quaternion.identity);
              yield return new WaitForSeconds(spawnInterval);
          }
      }
    */

}

