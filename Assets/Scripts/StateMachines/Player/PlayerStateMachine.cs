using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController characterController { get; private set; }
    [field: SerializeField] public Animator animator { get; private set; }
    [field: SerializeField] public float movementSpeed { get; private set; }
    [field: SerializeField] public GameObject prefabInstance { get; private set; }

    [field: SerializeField] public float bulletSpawnRate { get; private set; }
    [field: SerializeField] public float waitingTransition { get; private set; }
    [field: SerializeField] public float waitingStateDuration { get; private set; }
    [field: SerializeField] public float bulletSpeed { get; private set; }
    [field: SerializeField] public Material playerColor { get; private set; }

    private void Awake()
    {
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
                GameObject projectile = Instantiate(prefabInstance, transform.position, transform.rotation);
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.AddForce(direction * bulletSpeed, ForceMode.VelocityChange);
            }
    }
}