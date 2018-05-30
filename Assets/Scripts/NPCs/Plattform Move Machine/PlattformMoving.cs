using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformMoving : MonoBehaviour {

    // Holds the startposition of the platform
    private Vector3 m_startposition;

    private Vector3 m_endPositionL = Vector3.zero;

    private Vector3 m_endPositionR = Vector3.zero;

    public float m_moveStep;

    public float m_moveLength;


    public void SetStartPosition(Vector3 _position)
    {
        m_startposition = _position;
    }

    public Vector3 GetStartPosition()
    {
        return m_startposition;
    }

    public Vector3 GetMovingVectorX()
    {
        return new Vector3(m_moveStep, 0.0f, 0.0f);
    }

    private void CalculateEndPoints()
    {
        m_endPositionR = m_startposition + new Vector3(m_moveLength, 0.0f, 0.0f);
        m_endPositionL = m_startposition - new Vector3(m_moveLength, 0.0f, 0.0f);
    } 

    public Vector3 GetEndPositionL()
    {
        if (m_endPositionL == Vector3.zero)
        {
            CalculateEndPoints();
        }
        return m_endPositionL;
    }

    public Vector3 GetEndPositionR()
    {
        if (m_endPositionR == Vector3.zero)
        {
            CalculateEndPoints();
        }
        return m_endPositionR;
    }

}
