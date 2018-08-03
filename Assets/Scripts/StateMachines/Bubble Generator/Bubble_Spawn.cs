using UnityEngine;

namespace BubbleGenerator
{
    public class Bubble_Spawn : StateMachineBehaviour
    {
        /* Methods */

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("IsSpawned", false);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(!animator.GetBool("IsSpawned"))
            {
                animator.gameObject.GetComponent<BubbleGenerator>().SpawnBubble();
                animator.SetBool("IsSpawned", true);
            }             
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    }

}
