using UnityEngine;

namespace ColorChange
{
    /// <summary>
    ///  This script should be attached to the player
    ///  When active, it should activate every Coloration Script on every GameObject
    /// </summary>
    public class Player_ColorEffect : MonoBehaviour
    {


        [Range(0.1f, 2.0f)]
        public float m_CastRadius;

        /* Methods */

        private void LateUpdate()
        {
            // Find all objects in the give radius
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, m_CastRadius);

            // For every found object
            foreach (Collider2D hit in hits)
            {
                // Get Coloration script attachted on the collison partner
                Coloration coleration = hit.gameObject.GetComponent<Coloration>();

                // If there is a Coloration script ...
                if (coleration != null)
                {
                    // Activate the coloration
                    coleration.ActivateColor();
                }
            }
        }
    }

}
