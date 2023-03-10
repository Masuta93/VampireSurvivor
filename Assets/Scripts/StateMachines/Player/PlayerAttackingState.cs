using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    public PlayerAttackingState(PlayerStateMachine stateMachine) : base(stateMachine) { }
    private float spawnTimer = 0f;
    private float lastAttack = 0f;

    public override void Enter()
    {
        stateMachine.playerColor.color = Color.green;

    }

    public override void Tick(float deltaTime)
    {

        spawnTimer += deltaTime;
        lastAttack += deltaTime;

        if (spawnTimer >= stateMachine.bulletSpawnRate)
        {
            stateMachine.Attack();
            stateMachine.rewardManager.multipleShot.Invoke();
            spawnTimer = 0f;
        }

        if (lastAttack >= stateMachine.bulletSpawnRate + stateMachine.waitingTransition)
        {
            lastAttack = 0f;
            stateMachine.SwitchState(new PlayerWaitingState(stateMachine));
        }

    }

    public override void Exit()
    {

    }

    public override void PhysicsTick()
    {

        Move();
    }
}
