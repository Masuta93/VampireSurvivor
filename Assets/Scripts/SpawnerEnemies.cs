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
    public AnimationCurve spawnRateCurve;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    void Start()
    {
        spawnRateCurve = new AnimationCurve();
        StartCoroutine(spawnEnemy(spawnTimer, simpleEnemy));
    }

    void Update()
    {
        spawnTimer = spawnRateCurve.Evaluate(Time.time);
    }

    private IEnumerator spawnEnemy(float timer, GameObject enemy)
    {
        while (true)
        {
            Vector3 randomPos = mainCamera.transform.position + Random.insideUnitSphere * spawnRadius;
            randomPos.y = 0;

            Instantiate(simpleEnemy, randomPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

