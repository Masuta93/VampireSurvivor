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


    public override void PhysicsTick()
    {
        Move();
    }
}
