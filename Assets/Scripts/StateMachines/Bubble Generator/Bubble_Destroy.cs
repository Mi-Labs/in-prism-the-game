using UnityEngine;

namespace BubbleGenerator
{
    public class Bubble_Destroy : StateMachineBehaviour
    {
        /* Fields */

        private GameObject m_ActualBubble;


        /* Methods */

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("IsDestroyed", false);
            m_ActualBubble = animator.gameObject.GetComponent<BubbleGenerator>().GetActualBubble();

        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

            if(m_ActualBubble != null)
            {
                animator.gameObject.GetComponent<BubbleGenerator>().DestroyBubble();
                animator.SetBool("IsDestroyed", true);
            }

        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    }

}
