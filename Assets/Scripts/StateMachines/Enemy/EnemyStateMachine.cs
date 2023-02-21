using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [SerializeField] Transform player;
    [SerializeField] float chaseSpeed = 5;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        SwitchState(new EnemyAttackingState(this));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChasePlayer()
    {
        transform.LookAt(player);
        transform.position += transform.forward * chaseSpeed * Time.deltaTime;
    }
}
