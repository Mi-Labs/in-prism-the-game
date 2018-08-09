using Helper;
using UnityEngine;

namespace Spheres
{
    public class SphereFreed : MonoBehaviour
    {

        public float m_RiseSpeed;

        public float m_RiseHeight;

        private Rigidbody2D m_SphereBody;

        private Vector2 m_RiseVector;

        private bool m_ShouldRise;

        private Vector3 m_PlayerStartPosition;

        private Vector3 m_Endposition;

        // Use this for initialization
        void Start()
        {
            m_RiseVector = new Vector2(0.0f, m_RiseSpeed);
            m_SphereBody = gameObject.GetComponent<Rigidbody2D>();
            m_ShouldRise = false;
            m_PlayerStartPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            m_Endposition = m_PlayerStartPosition + new Vector3(0.0f, m_RiseHeight, 0.0f);
        }

        private void Update()
        {
            if(m_ShouldRise)
            {
                m_SphereBody.AddForce(m_RiseVector*Time.deltaTime);
                if(WayCalculation.CalculateWayLeftY(transform.position, m_Endposition) == false)
                {
                    Debug.Log("No way left");
                    m_ShouldRise = false;
                    Destroy(gameObject);            
                }            
            }
        }


        public void RiseSphere()
        {
            m_ShouldRise = true;
        }
    }

}
