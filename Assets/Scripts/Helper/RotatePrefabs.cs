using UnityEngine;

namespace Helper
{
    public class RotatePrefabs : MonoBehaviour
    {

        public float m_RotationX, m_RotationY, m_RotationZ;

        private GameObject m_Object;

        // Use this for initialization
        void Start()
        {
            m_Object = gameObject;
            m_Object.transform.Rotate(m_RotationX, m_RotationY, m_RotationZ);
        }

    }
}

