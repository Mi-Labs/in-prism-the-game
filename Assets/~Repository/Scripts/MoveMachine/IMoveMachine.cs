using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveMachine
{
    // Used for updating the current state
    void UpdateState();

    // Used to switch to MoveState
    void ToMoveState();

    //Used to switch to WaitState
    void ToWaitState();

    // Used to Interact with Triggers
    void OnTriggerEnter2D(Collider2D other);

}
