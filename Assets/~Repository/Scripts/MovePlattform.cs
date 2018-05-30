using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlattform : StateMachineBehaviour {

    public float lengthMovement = 30; //is the length the object should move
    public GameObject movingObjekt; // defines the object you want to move
    private Vector3 startPosition;
    private float endpos;

    private void Awake()
    {
        Debug.Log("Move Machine awake");
        startPosition = movingObjekt.transform.position;
        endpos = startPosition.x + lengthMovement;
        Debug.Log("Start position: " + startPosition);
        Debug.Log("End position: " + endpos);
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       // Debug.Log("move");
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        float smoothMove = 0.0f;
        
        
        if (movingObjekt.transform.position.x != endpos)
        {
            smoothMove = smoothMove + 1.0f;
            movingObjekt.transform.position += new Vector3(smoothMove, 0.0f, 0.0f);
            Debug.Log("MovePosition: "+movingObjekt.transform.position);
        }
        else
        {
            movingObjekt.transform.position = startPosition;
            Debug.Log("Reset position");
        }
        Debug.Log("Move again");
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log("Out");
    }

	
}
