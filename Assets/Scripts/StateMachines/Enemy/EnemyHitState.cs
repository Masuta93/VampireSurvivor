using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitState : EnemyBaseState
{
    private float timer = 0f;
    public EnemyHitState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.enemyColor.material.color = Color.red;
    }

    public override void Tick(float deltaTime)
    {
        timer += deltaTime;
        ChasePlayer(new Vector3(stateMachine.player.transform.position.x, 1, stateMachine.player.transform.position.z), stateMachine.chaseSpeed, deltaTime);
        if(timer > .2) 
        {
            stateMachine.SwitchState(new EnemyAttackingState(stateMachine));
        }
    }

    public override void PhysicsTick()
    {
    }
    public override void Exit()
    {
        stateMachine.enemyColor.material.color = Color.black;
    }

}
