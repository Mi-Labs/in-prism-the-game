using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlatformMovement
{
    public class InitMoveMachine : StateMachineBehaviour
    {

        private bool m_FinishInit;

        private int m_Direction;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // Debug.Log("Started State Machine - State Init started");
            m_FinishInit = false;
            m_Direction = (int) animator.gameObject.GetComponent<PlattformMoving>().m_Direction;
            animator.SetBool("HasInitalized", false);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!m_FinishInit)
            {
                animator.gameObject.GetComponent<PlattformMoving>().SetStartPosition(animator.gameObject.transform.position);
                m_FinishInit = true;
                animator.SetBool("HasInitalized", true);
                animator.SetInteger("MoveAxis", m_Direction);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // Debug.Log("State Init was left");
        }
    }
}
