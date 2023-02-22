using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public float chaseSpeed { get; private set; }
    public GameObject player { get; private set; }
    public KillCount killCount { get; private set; }
    [field: SerializeField] public Statistiques statistiquesEnemy { get; private set; }
    [SerializeField] public PlayerStateMachine damageToEnemy { get; private set; }
    [SerializeField] public Renderer enemyColor { get; private set; }

    [SerializeField] public RewardsManager rewardManager { get; private set; } 

    private int maxHealth;
    private int currentHealth;
    private bool isDead;

    private void Awake()
    {
        enemyColor = GetComponentInChildren<Renderer>();

        damageToEnemy = GameObject.Find("----Player----").GetComponent<PlayerStateMachine>();
        rewardManager = GameObject.Find("Rewards").GetComponent<RewardsManager>();

        maxHealth = statistiquesEnemy.maxHealth;
        currentHealth = maxHealth;

        player = GameObject.Find("----Player----");
        killCount = GameObject.Find("killCount").GetComponent<KillCount>();
    }
    void Start()
    {
        SwitchState(new EnemyAttackingState(this));
    }

    private void OnTriggerEnter(Collider other)
    {
        int damage = damageToEnemy.statistiquesPlayer.damages;
        float timer = 0;
        timer += Time.deltaTime;
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet") /* && isDead != true*/)
        {
            dealDamageToPlayer(damage);
        }
    }

    public void dealDamageToPlayer(int damage)
    {

        currentHealth -= damage;
        if (currentHealth <= 0) { currentHealth = 0; }
        if (currentHealth <= 0)
        {
            SwitchState(new EnemyDeathState(this));
            /*killCount.ScoreAdd();
            Destroy(gameObject);
            isDead = true;
            rewardManager.afterDeath.Invoke(); */
        }
        SwitchState(new EnemyHitState(this));
    }

    public void Death()
    {
        killCount.ScoreAdd();
        Destroy(gameObject);
        rewardManager.afterDeath.Invoke();
    }
}
