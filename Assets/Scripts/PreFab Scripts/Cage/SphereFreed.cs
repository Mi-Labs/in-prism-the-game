using Helper;
using UnityEngine;

namespace Spheres
{
    public class SphereFreed : MonoBehaviour
    {
        /* Fields */

        public float m_RiseSpeed;
        [Space(20)]
        public float m_RiseHeight;
        [SerializeField]
        private Rigidbody2D m_SphereBody;
        [SerializeField]
        private Vector2 m_RiseVector;
        [SerializeField]
        private bool m_ShouldRise;
        [SerializeField]
        private Vector3 m_PlayerStartPosition;
        [SerializeField]
        private Vector3 m_Endposition;


        /* Methods */

        // Use this for initialization
        void Start()
        {
            // Initalize the fields
            m_RiseVector = new Vector2(0.0f, m_RiseSpeed);
            m_SphereBody = gameObject.GetComponent<Rigidbody2D>();
            m_ShouldRise = false;
            m_Endposition =  gameObject.transform.parent.transform.position + new Vector3(0.0f, m_RiseHeight, 0.0f);
        }



        private void Update()
        {
            if(m_ShouldRise)
            {
               
                // Add Force that move the sphere upward
                m_SphereBody.AddForce(m_RiseVector*Time.deltaTime);


                // If the sphere is near the endpoint, destroy it
                if (WayCalculation.CalculateWayLeftY(transform.position, m_Endposition) == false)
                {
                    Destroy(gameObject);
                }
            }
        }

        /// <summary>
        /// Start the rising process
        /// </summary>
        public void RiseSphere()
        {
            m_ShouldRise = true;
            m_SphereBody.constraints = RigidbodyConstraints2D.None;
        }

  
    }

}
