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
        Vector3 movement = CalculateMovement();

        Move(movement * stateMachine.movementSpeed, deltaTime);

        spawnTimer += deltaTime;
        lastAttack += deltaTime;

        if (spawnTimer >= stateMachine.bulletSpawnRate)
        {
            stateMachine.Attack();
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

    private Vector3 CalculateMovement()
    {
        Vector3 forward = stateMachine.transform.forward;
        Vector3 right = stateMachine.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        return forward * stateMachine.InputReader.MovementValue.y + right * stateMachine.InputReader.MovementValue.x;
    }
}
