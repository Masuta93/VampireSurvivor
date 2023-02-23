using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RewardsManager : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private KillCount killCount;
    [SerializeField] private GameObject rewards;
    [SerializeField] private int palierReward = 10;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    public Vector3 enemyDeathPos;

    public UnityEvent afterDeath;
    public UnityEvent multipleShot;
    private bool pause;
    private int countValue;

    private void Awake()
    {
        countValue = killCount._value;
    }
    void Start()
    {
    }

    void Update()
    {
        countValue = killCount._value;
        if (countValue == palierReward && pause == false)
        {
            Pause();
            rewards.SetActive(true);
        }
        else if (countValue == palierReward + 1)
        {
            pause = false;
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        pause = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        rewards.SetActive(false);
    }

    public void Button1()
    {
        afterDeath.AddListener(randomShotFromDeadEnemy);
        Resume();
    }
    public void Button2()
    {
        multipleShot.AddListener(SecondShot);
        Resume();
    }
    public void randomShotFromDeadEnemy()
    {
        enemy.GetComponent<EnemyStateMachine>().Explosion(enemyDeathPos);
    }

    public void SecondShot()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            return;
        }
        else if (rand == 1)
        {
            StartCoroutine(DelayedSecondShot(0.2f));
        }
    }
    private IEnumerator DelayedSecondShot(float delay)
    {
        yield return new WaitForSeconds(delay);
        player.GetComponent<PlayerStateMachine>().Attack();
    }
}
