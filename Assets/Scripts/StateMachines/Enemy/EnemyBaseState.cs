using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void ChasePlayer(Vector3 player, float chaseSpeed, float deltaTime)
    {
        stateMachine.transform.LookAt(player);
        stateMachine.transform.position += stateMachine.transform.forward * chaseSpeed * deltaTime;
       // stateMachine.transform.Translate(player * chaseSpeed * deltaTime);
    }
}

