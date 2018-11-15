using UnityEngine;

namespace ColorChange
{
    /// <summary>
    /// This class saves the original color of the GO
    /// -> Must be attached to every object with colorchanging mechanic
    /// </summary>
    public class Coloration : MonoBehaviour
    {


        /* Fields */

        // Holds boolean (if true -> color should be applied to GO)
        [SerializeField]
        private bool m_IsColorful;

        private World_Config m_Config;


        /* Methods */

        void Start()
        {
            m_IsColorful = false;
            m_Config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();
        }


        /// <summary>
        ///  This method gets the status of the colorfulness of the object
        /// </summary>
        /// <returns>The status of the colorfulness</returns>
        public bool GetIsColorful()
        {
            return m_IsColorful;
        }


        /// <summary>
        /// If this method is called, the GO changes to the saved color
        /// </summary>
        public void ActivateColor()
        {
            if (!m_IsColorful)
            {
                // Change the color of this GameObjects SpriteRenderer to the assigned color
                SpriteRenderer[] spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();

                foreach (SpriteRenderer renderer in spriteRenderers)
                {
                    renderer.material = m_Config.m_DefaultSpriteMaterial;
                }

                // Set the colorfulness to true
                m_IsColorful = true;

                if(gameObject.GetComponent<ChangedValues>() != null)
                {
                    gameObject.GetComponent<ChangedValues>().ColorChanged(true);
                }
                else
                {
                //    Debug.Log("No Changed Value script on: " + gameObject.name);
                }
                
            }
        }
    }
}
