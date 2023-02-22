using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine) { }


    public override void Enter()
    {
        stateMachine.Death();
    }

    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {
    }

    public override void PhysicsTick()
    {
    }

}
