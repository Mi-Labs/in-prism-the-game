using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMoveMachine : StateMachineBehaviour {

    private bool m_finishInit;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Started State Machine - State Init started");
        m_finishInit = false;
        animator.SetBool("HasInitalized", false);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!m_finishInit)
        {
            animator.gameObject.GetComponent<PlattformMoving>().SetStartPosition(animator.gameObject.transform.position);
            m_finishInit = true;
            animator.SetBool("HasInitalized", true);
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("State Init was left");
	}

   

}
