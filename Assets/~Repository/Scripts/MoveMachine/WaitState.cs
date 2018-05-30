using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : IMoveMachine {

    private MoveMachine machine;

    private bool hasWaited;

    public WaitState(MoveMachine machine)
    {
        this.machine = machine;
    }
    // Used for updating the current state
    public void UpdateState()
    {
        machine.Wait();
    }

    // Used to switch to MoveState
    public void ToMoveState()
    {
       if(machine.hadwaited)
        {
            machine.currentState = machine.moveState;
        }
    }

    //Used to switch to WaitState
    public void ToWaitState()
    {

        Debug.Log("Can't switch to current active state");
    }

    // Used to Interact with Triggers
    public void OnTriggerEnter2D(Collider2D other)
    {

    }


}
