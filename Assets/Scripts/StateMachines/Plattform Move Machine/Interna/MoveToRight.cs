using UnityEngine;
using Helper;

namespace PlatformMovement
{
    public class MoveToRight : StateMachineBehaviour
    {
        /* Fields */

        private Vector3 m_endPositionRight;

        private Vector3 m_movingVector;

        private Vector3 m_actualPosition;


        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("ReachRightEnd", false);
            m_movingVector = animator.gameObject.GetComponent<PlattformMoving>().GetMovingVector(1);
            m_endPositionRight = animator.gameObject.GetComponent<PlattformMoving>().GetEndPosition(4);

        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Vector3 actualPosition = animator.gameObject.transform.position;

            bool isWayLeft = WayCalculation.CalculateWayLeftX(actualPosition, m_endPositionRight);

            if (!isWayLeft)
            {
                animator.SetBool("ReachRightEnd", true);

            }
            else
            {
                animator.gameObject.transform.position += m_movingVector *Time.deltaTime;
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.gameObject.GetComponent<PlattformMoving>().FlipPlattformLeft(false);
        }

    }
}

