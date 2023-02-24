using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    //  [field: SerializeField] public CharacterController characterController { get; private set; }

    [field: SerializeField] public Rigidbody rb { get; private set; }
    [field: SerializeField] public Animator animator { get; private set; }
    [field: SerializeField] public float movementSpeed { get; private set; }
    [field: SerializeField] public GameObject prefabInstance { get; private set; }

    [field: SerializeField] public float bulletSpawnRate { get; private set; }
    [field: SerializeField] public float waitingTransition { get; private set; }
    [field: SerializeField] public float waitingStateDuration { get; private set; }
    [field: SerializeField] public float bulletSpeed { get; private set; }
    [field: SerializeField] public Material playerColor { get; private set; }
    [field: SerializeField] public Statistiques statistiquesPlayer { get; private set; }
    [field: SerializeField] public RewardsManager rewardManager { get; private set; }

    [field: SerializeField] public HealthBar healthBar { get; private set; }

    [field: SerializeField] public GameObject retryText { get; private set; }

    public int maxHealth { get; private set; }
    public int currentHealth { get; private set; }

    private void Awake()
    {
        retryText.SetActive(false);
        rewardManager = GameObject.Find("Rewards").GetComponent<RewardsManager>();
        rb = GetComponent<Rigidbody>();
        maxHealth = statistiquesPlayer.maxHealth;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Start()
    {
        SwitchState(new PlayerAttackingState(this));
    }

    public void Attack()
    {
            for (int i = 0; i < 4; i++)
            {
                // Calculer la direction en fonction de la valeur de i
                Vector3 direction = Vector3.zero;
                if (i == 0) direction = transform.forward;
                else if (i == 1) direction = -transform.forward;
                else if (i == 2) direction = -transform.right;
                else if (i == 3) direction = transform.right;

                // Instancier le projectile et lui ajouter une force dans la direction calculée
                GameObject projectile = Instantiate(prefabInstance, new Vector3 (transform.position.x, 1, transform.position.z), transform.rotation);
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.AddForce(direction * bulletSpeed, ForceMode.VelocityChange);
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        int damage = collision.gameObject.GetComponent<EnemyStateMachine>().statistiquesEnemy.damages;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            dealDamage(damage);
            healthBar.SetHealth(currentHealth);
        }
    }

    public void dealDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) 
        { 
            currentHealth= 0;
            SwitchState(new PlayerDeathState(this));
        }
    }

    public void removeGameObject()
    {
        Destroy(gameObject);
    }
}