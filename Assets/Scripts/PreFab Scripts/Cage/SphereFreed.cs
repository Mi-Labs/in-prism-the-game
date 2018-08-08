using Helper;
using UnityEngine;

namespace Spheres
{
    public class SphereFreed : MonoBehaviour
    {

        public float m_RiseSpeed;

        public float m_RiseHeight;

        //private Rigidbody2D m_SphereBody;

        private Vector3 m_RiseVector;

        private bool m_ShouldRise;

        private Vector3 m_PlayerStartPosition;

        private Vector3 m_Endposition;


        // Use this for initialization
        void Start()
        {
            m_RiseVector = new Vector3(0.0f, m_RiseSpeed, 0.0f);
            //m_SphereBody = gameObject.GetComponent<Rigidbody2D>();
            m_ShouldRise = false;
            m_PlayerStartPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            m_Endposition = m_PlayerStartPosition + new Vector3(0.0f, m_RiseHeight, 0.0f);
        }

        private void Update()
        {
            if(m_ShouldRise)
            {
                gameObject.transform.position += m_RiseVector * Time.deltaTime;
                m_ShouldRise = WayCalculation.CalculateWayLeftY(transform.position, m_Endposition);
                if(!m_ShouldRise)
                {
                    Destroy(this.gameObject);
                }
            }
        }


        public void RiseSphere()
        {
            m_ShouldRise = true;
        }
    }

}
