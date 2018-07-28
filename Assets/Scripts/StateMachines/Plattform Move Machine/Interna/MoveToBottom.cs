using UnityEngine;

namespace PlatformMovement
{
    public class MoveToBottom : StateMachineBehaviour
    {
        private Vector3 m_endPositionTop;

        private Vector3 m_movingVector;

        private Vector3 m_actualPosition;


        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

            animator.SetBool("ReachBottom", false);
            m_movingVector = animator.gameObject.GetComponent<PlattformMoving>().GetMovingVector(2);
            m_endPositionTop = animator.gameObject.GetComponent<PlattformMoving>().GetEndPosition(1);

        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Vector3 actualPosition = animator.gameObject.transform.position;

            bool isWayLeft = CalculateWayLeft(actualPosition, m_endPositionTop);

            if (!isWayLeft)
            {
                animator.SetBool("ReachBottom", true);
            }
            else
            {
                animator.gameObject.transform.position -= m_movingVector;
            }

        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }

        private bool CalculateWayLeft(Vector3 _actualPosition, Vector3 _destination)
        {
            return (Mathf.Abs((_actualPosition.y - _destination.y)) <= 0.1f) ? false : true;
        }
    }
}