using UnityEngine;

namespace PlatformMovement
{
    public class PlattformMoving : MonoBehaviour
    {

        public EDirection m_Direction;

        public bool m_ShouldFlipLeft;

        public float m_MoveStep;

        public float m_MoveLength;

        // Holds the startposition of the platform
        private Vector3 m_startposition;

        // Holds the endposition (Top, Bottom, Left, Right)
        private Vector3 m_endPositionT, m_endPositionB, m_endPositionL, m_endPositionR = Vector3.zero;


        public enum EDirection : int
        {
            X_Axis = 1,
            Y_Axis = 2
        }



        public void SetStartPosition(Vector3 _position)
        {
            m_startposition = _position;
        }

        public Vector3 GetStartPosition()
        {
            return m_startposition;
        }


        /// <summary>
        /// This method gets the move vector for the platform
        /// </summary>
        /// <param name="_axis">(X-Axis = 1, Y-Axis = 2)</param>
        /// <returns>The moving Vector for the platform</returns>
        public Vector3 GetMovingVector(int _axis)
        {
            if (_axis == 1)
            {
                return new Vector3(m_MoveStep, 0.0f, 0.0f);
            }
            if (_axis == 2)
            {
                return new Vector3(0.0f, m_MoveStep, 0.0f);
            }

            return Vector3.zero;
        }


        


        /// <summary>
        /// This method 
        /// </summary>
        /// <param name="_direction">(Bottom-1, Top-2,Left-3, Right-4)</param>
        /// <returns>Endposition for the movement</returns>
        public Vector3 GetEndPosition(int _direction)
        {
            Vector3 endPosition = Vector3.one;

            switch (_direction)
            {
                case 1:
                    endPosition = m_endPositionB;
                    break;

                case 2:
                    endPosition = m_endPositionT;
                    break;

                case 3:
                    endPosition = m_endPositionL;
                    break;

                case 4:
                    endPosition = m_endPositionR;
                    break;

                default:
                    Debug.LogError("Invalid direction");
                    break;
            }

            if (endPosition == Vector3.zero)
            {
                CalculateEndPoints();
            }

            switch (_direction)
            {
                case 1:
                    return m_endPositionB;

                case 2:
                    return m_endPositionT;

                case 3:
                    return m_endPositionL;

                case 4:
                    return m_endPositionR;

                default:
                    Debug.LogError("Invalid direction");
                    break;
            }

            return Vector3.zero;
        }

        public void FlipPlattformLeft(bool _status)
        {
            if(m_ShouldFlipLeft)
            {
                if (_status)
                {
                    gameObject.transform.Rotate(0.0f, 180, 0.0f);
                }
                else
                {
                    gameObject.transform.Rotate(0.0f, -180, 0.0f);
                }
            }          
        }

        private void CalculateEndPoints()
        {
            if (m_Direction == EDirection.X_Axis)
            {
                m_endPositionR = m_startposition + new Vector3(m_MoveLength, 0.0f, 0.0f);
                m_endPositionL = m_startposition - new Vector3(m_MoveLength, 0.0f, 0.0f);
            }
            else if (m_Direction == EDirection.Y_Axis)
            {
                m_endPositionT = m_startposition + new Vector3(0.0f, m_MoveLength, 0.0f);
                m_endPositionB = m_startposition - new Vector3(0.0f, m_MoveLength, 0.0f);
            }

        }
    }

   
}

