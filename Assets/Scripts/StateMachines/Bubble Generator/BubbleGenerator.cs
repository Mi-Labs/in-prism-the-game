using UnityEngine;

namespace BubbleGenerator
{
    public class BubbleGenerator : MonoBehaviour
    {
        /* Fields */

        public float m_RiseSpeed;
        public float m_EndSize;
        public float m_ScaleSteps;
        public float m_YEndHight;

        [Space(20)]
        public GameObject m_BubblePrefab;

        private GameObject m_ActualBubble;


        /* Methods */

        /// <summary>
        /// This method gets the endpoint for the bubble rise
        /// </summary>
        /// <returns>The endposition</returns>
        public Vector3 GetEndPoint()
        {
            return new Vector3(gameObject.transform.position.x, m_YEndHight, gameObject.transform.position.z);
        }

        /// <summary>
        /// This method gives the actual bubble
        /// </summary>
        /// <returns></returns>
        public GameObject GetActualBubble()
        {
            return m_ActualBubble;
        }


        /// <summary>
        /// This method spawns a bubble at the position of the bubble generator
        /// </summary>
        public void SpawnBubble()
        {
            if(m_ActualBubble == null)
            {
                // Get the startposition for the bubble clone
                Vector3 startposition = new Vector3(transform.position.x, 0.5f, transform.position.z);
                m_ActualBubble = Instantiate(m_BubblePrefab, startposition, Quaternion.identity, transform);
            }
        }


        /// <summary>
        /// This method destroys the actual bubble
        /// </summary>
        public void DestroyBubble()
        {
            if(m_ActualBubble != null)
            {
                Destroy(m_ActualBubble);
                m_ActualBubble = null;
            }
        }
    }
}
