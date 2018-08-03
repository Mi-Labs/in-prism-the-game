using UnityEngine;

namespace PlatformMovement
{
    public class MoveToLeft : StateMachineBehaviour
    {

        private Vector3 m_endPositionLeft;

        private Vector3 m_movingVector;

        private Vector3 m_actualPosition;


        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

            animator.SetBool("ReachLeftEnd", false);
            m_movingVector = animator.gameObject.GetComponent<PlattformMoving>().GetMovingVector(1);
            m_endPositionLeft = animator.gameObject.GetComponent<PlattformMoving>().GetEndPosition(3);

        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Vector3 actualPosition = animator.gameObject.transform.position;

            bool isWayLeft = CalculateWayLeft(actualPosition, m_endPositionLeft);

            if (!isWayLeft)
            {
                animator.SetBool("ReachLeftEnd", true);
                animator.gameObject.GetComponent<PlattformMoving>().FlipPlattformLeft(true);
            }
            else
            {
                animator.gameObject.transform.position -= m_movingVector * Time.deltaTime ;
            }

        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }

        private bool CalculateWayLeft(Vector3 _actualPosition, Vector3 _destination)
        {
            return (Mathf.Abs((_actualPosition.x - _destination.x)) <= 0.1f) ? false : true;
        }
    }
}

