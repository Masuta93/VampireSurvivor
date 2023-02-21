using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.player != null)
        { ChasePlayer(new Vector3(stateMachine.player.transform.position.x, 1, stateMachine.player.transform.position.z), stateMachine.chaseSpeed, deltaTime); }
    }

    public override void Exit()
    {
    }

    public override void PhysicsTick()
    {
    }
}
