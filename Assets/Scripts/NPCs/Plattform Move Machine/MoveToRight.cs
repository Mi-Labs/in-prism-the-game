﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRight : StateMachineBehaviour {

    private Vector3 m_endPositionRight;

    private Vector3 m_movingVector;

    private Vector3 m_actualPosition;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("ReachRightEnd", false);
        m_movingVector = animator.gameObject.GetComponent<PlattformMoving>().GetMovingVectorX();
        m_endPositionRight = animator.gameObject.GetComponent<PlattformMoving>().GetEndPositionR();
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 actualPosition = animator.gameObject.transform.position;

        bool isWayLeft = CalculateWayLeft(actualPosition, m_endPositionRight);
        
        if (!isWayLeft)
        {
            animator.SetBool("ReachRightEnd", true);
        }
        else
        {
            animator.gameObject.transform.position += m_movingVector;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {}

    private bool CalculateWayLeft(Vector3 _actualPosition, Vector3 _destination)
    {
        return (Mathf.Abs((_actualPosition.x - _destination.x)) <= 0.1f) ? false : true;
    }
}