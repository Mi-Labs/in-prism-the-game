using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwipeDetector : MonoBehaviour {

    // Startpoint of the touch
    private Vector2 m_FingerDownPosition;

    // Endpoint of the touch
    private Vector2 m_FingerUpPosition;


    public bool m_DetectSwipeOnlyAfterRelease = false;

    public float m_MinDistanceForSwipe = 20f;

    public static event Action<SwipeData> OnSwipe = delegate { };
	
	// Update is called once per frame
	void Update ()
    {
	    foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                m_FingerUpPosition = touch.position;
                m_FingerDownPosition = touch.position;
            }
            if(!m_DetectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                m_FingerDownPosition = touch.position;
                DetectSwipe();
                
            }
            if(touch.phase == TouchPhase.Ended)
            {
                m_FingerDownPosition = touch.position;
                DetectSwipe();
            }

        }
	}

    private void DetectSwipe()
    {
        if(SwipeDistanceIsValid())
        {
            if(IsVerticalSwipe())
            {
                var dircetion = m_FingerDownPosition.y - m_FingerUpPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendSwipe(dircetion);
            }
            else
            {
                var direction = m_FingerDownPosition.x - m_FingerUpPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                SendSwipe(direction);
            }
            // Reset fingerposition to endpoint
            m_FingerUpPosition = m_FingerDownPosition;
        }
    }

    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();  
    }

    private bool SwipeDistanceIsValid()
    {
        return VerticalMovementDistance() > m_MinDistanceForSwipe || HorizontalMovementDistance() > m_MinDistanceForSwipe;
    }

    /// <summary>
    /// This method returns the distance between start and end of the touch on y-Axis
    /// </summary>
    /// <returns>The distance(abs) between start and end of the touch</returns>
    private float VerticalMovementDistance()
    {
        return Mathf.Abs(m_FingerDownPosition.y - m_FingerUpPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(m_FingerDownPosition.x - m_FingerUpPosition.x);
    }

    private void SendSwipe(SwipeDirection _direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            direction = _direction,
            startPosition = m_FingerDownPosition,
            endPosition = m_FingerUpPosition
        };
        OnSwipe(swipeData);
    }


    public struct SwipeData
    {
        public Vector2 startPosition;
        public Vector2 endPosition;
        public SwipeDirection direction;
    }

    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}
