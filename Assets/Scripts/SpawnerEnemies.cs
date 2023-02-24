using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] Transform groundSize;
    [SerializeField] GameObject simpleEnemy;
    [SerializeField] float spawnTimer;
    [SerializeField] private Vector3 spawnArea;
    [SerializeField] RewardsManager pause;
    public AnimationCurve spawnRateCurve;
    [SerializeField] private CinemachineVirtualCamera mainCamera;
    float timer;

    private void Awake()
    {
       // mainCamera = Camera.main;
    }
    void Start()
    {
    }

    void Update()
    {
        if (!pause.spawnPause)
        {
            spawnTimer *= spawnRateCurve.Evaluate(Time.time);
            if (spawnTimer <= 0.1f)
            {
                spawnTimer = 0.1f;
            }
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                SpawnEnemy();
                timer = spawnTimer;
            }
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

        float f = UnityEngine.Random.Range(0,4);
        float cameraZ = mainCamera.transform.position.z;
        float cameraX = mainCamera.transform.position.x;
        switch (f)
        {
            case 0:
                {
                    // gauche
                    position.x = UnityEngine.Random.Range((-spawnArea.x - 5 + cameraX), -spawnArea.x + cameraX);
                    position.z =  UnityEngine.Random.Range((-spawnArea.z - 3 + cameraZ), spawnArea.z + 3 + cameraZ);
                    break;
                }
            case 1:
                {
                    // droite 
                   position.x = UnityEngine.Random.Range((spawnArea.x + 5 + cameraX), spawnArea.x + cameraX);
                   position.z = UnityEngine.Random.Range((-spawnArea.z - 3 + cameraZ), spawnArea.z + 3 + cameraZ);
                    break;
                }
            case 2:
                {
                    // haut
                    position.x = UnityEngine.Random.Range((-spawnArea.x + cameraX), spawnArea.x + cameraX);
                    position.z = UnityEngine.Random.Range((spawnArea.z + 3 + cameraZ), spawnArea.z + cameraZ);
                    break;
                }
            case 3:
                {
                    // bas
                    position.x = UnityEngine.Random.Range((-spawnArea.x + cameraX), spawnArea.x + cameraX);
                    position.z = UnityEngine.Random.Range((-spawnArea.z - 3 + cameraZ), -spawnArea.z + cameraZ);
                    break;
                }
        }


        position.y = 1;

        return position;
    }
}

