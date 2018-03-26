using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IMoveMachine {


    private MoveMachine machine;

    public MoveState(MoveMachine machine)
    {
        this.machine = machine;
    }
    // Used for updating the current state
    public void UpdateState()
    {
        Move(machine.look_direction_left);
    }

    // Used to switch to MoveState
    public void ToMoveState()
    {
        Debug.Log("Can't switch to current active state");
    }

    //Used to switch to WaitState
    public void ToWaitState()
    {
        if(machine.target.transform.position.Equals(machine.endposition) || machine.target.transform.position.Equals(machine.startposition))
        {
            machine.currentState = machine.waitState;   
        }

    }

    // Used to Interact with Triggers
    public void OnTriggerEnter2D(Collider2D other)
    {

    }

    public void Move(bool direction_left)
    {
       if(direction_left)
        {
            machine.targetRB.velocity = Vector3.left;
        }
        else
        {
            machine.targetRB.velocity = Vector3.right;
        }
    }

    

}
