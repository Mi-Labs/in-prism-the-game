using UnityEngine;

namespace BubbleGenerator
{
    public class Bubble_Rise : StateMachineBehaviour
    {
        /* Fields */

        private GameObject m_ActualBubble;

        private Vector3 m_Endpositon;

        private float m_RiseSpeed;

        private Vector3 m_RiseVector;


        /* Methods */

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // Set bool for Stage change to false
            animator.SetBool("OnTop", false);
    
            // Init fields
            m_ActualBubble = animator.gameObject.GetComponent<BubbleGenerator>().GetActualBubble();
            m_Endpositon = animator.gameObject.GetComponent<BubbleGenerator>().GetEndPoint();
            m_RiseSpeed = animator.gameObject.GetComponent<BubbleGenerator>().m_RiseSpeed;
            m_RiseVector = GenerateRiseVector(m_RiseSpeed);
       
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // If there is a bubble...
            if(m_ActualBubble != null)
            {
                // Calculate the way left till destruction
                bool isWayLeft = CalculateWayLeft(m_ActualBubble.transform.position, m_Endpositon);
                // If there is way left till destruction...
                if (isWayLeft)
                {
                    // Add RiseVector to actual positon
                    m_ActualBubble.transform.position += m_RiseVector *Time.deltaTime;
                }
                else
                {
                    // Set bool for Stage change to true
                    animator.SetBool("OnTop", true);
                }
            }
        }


        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }


        /// <summary>
        /// This method checks, if there is way between the two given points
        /// </summary>
        /// <param name="_actualPosition">The actual position of the GO</param>
        /// <param name="_destination">The destination of the GO</param>
        /// <returns>True, if there is more than 0.1f way</returns>
        private bool CalculateWayLeft(Vector3 _actualPosition, Vector3 _destination)
        {
            return (Mathf.Abs((_actualPosition.y - _destination.y)) <= 0.1f) ? false : true;
        }


        /// <summary>
        /// This method generates the movement vector for the bubble
        /// </summary>
        /// <param name="m_RiseSpeed">The speed for the bubble to rise</param>
        /// <returns>The movement vector for the bubble</returns>
        private Vector3 GenerateRiseVector(float m_RiseSpeed)
        {
            return new Vector3(0.0f, m_RiseSpeed, 0.0f);
        }
    }
}
