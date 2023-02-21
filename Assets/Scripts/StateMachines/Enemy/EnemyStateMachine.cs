using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public float chaseSpeed { get; private set; }
    public GameObject player { get; private set; }
    public KillCount killCount { get; private set; }
    [field: SerializeField] public IntVariable statistiquesEnemy { get; private set; }
    [SerializeField] public PlayerStateMachine damageToEnemy { get; private set; }
    [SerializeField] public Renderer enemyColor { get; private set; }

    private int maxHealth;
    private int currentHealth;

    private void Awake()
    {
        enemyColor = GetComponentInChildren<Renderer>();

        if (player != null)
        {
            damageToEnemy = GameObject.Find("----Player----").GetComponent<PlayerStateMachine>();
        }

        maxHealth = statistiquesEnemy.maxHealth;
        currentHealth = maxHealth;

        player = GameObject.Find("----Player----");
        killCount = GameObject.Find("killCount").GetComponent<KillCount>();
    }
    void Start()
    {
        SwitchState(new EnemyAttackingState(this));
    }

    private void OnCollisionEnter(Collision collision)
    {
        int damage = damageToEnemy.statistiquesPlayer.damages;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
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
            killCount.ScoreAdd();
            Destroy(gameObject);
        }
        SwitchState(new EnemyHitState(this));
    }
}
