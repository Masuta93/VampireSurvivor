using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    protected void Move()
    {
        Vector3 movement = new Vector3(stateMachine.InputReader.MovementValue.x, 0, stateMachine.InputReader.MovementValue.y);
        if (movement.magnitude > 0 )
        {
            stateMachine.rb.velocity = movement.normalized * stateMachine.movementSpeed * 100;
         //   Vector3 targetVelocity = movement.normalized * stateMachine.movementSpeed * 100;
           // stateMachine.rb.velocity = Vector3.Lerp(stateMachine.rb.velocity, targetVelocity, 100);
    }
        else
        {
            stateMachine.rb.velocity = Vector3.zero;
        }
       // stateMachine.rb.velocity = (new Vector3(stateMachine.InputReader.MovementValue.x, 0, stateMachine.InputReader.MovementValue.y) * stateMachine.movementSpeed * 100);
    }
}
