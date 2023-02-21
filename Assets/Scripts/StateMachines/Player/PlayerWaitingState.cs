using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaitingState : PlayerBaseState
{
    private float spawnTimer = 0f;
    public PlayerWaitingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.playerColor.color = Color.white;

    }
    public override void Tick(float deltaTime)
    {


        spawnTimer += deltaTime;
        if (spawnTimer >= stateMachine.waitingStateDuration)
        {
            spawnTimer = 0.0f;
            stateMachine.SwitchState(new PlayerAttackingState(stateMachine));
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

    public override void PhysicsTick()
    {
        Vector3 movement = CalculateMovement();

        Move(new Vector3(stateMachine.InputReader.MovementValue.x, 0, stateMachine.InputReader.MovementValue.y) * stateMachine.movementSpeed * 100);
    }
}
