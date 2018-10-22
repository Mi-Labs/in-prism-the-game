using UnityEngine;
using System;

namespace Spheres
{
    public class CageBehavior : MonoBehaviour
    {
        /* Fields */
        
        public int m_CageStage;
        public Sprite m_CageBroken;

        private SpriteRenderer m_CageRenderer;
        private SphereFreed m_SphereScript;

        //public static event Action<bool> SphereFreed = delegate { };

        /* Methods */

        void Start()
        {
            // Init fields
            m_CageStage = 2;

            // Search for spriteRenderer of the cage sprite
            SpriteRenderer[] renderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer renderer in renderers)
            {
                if (renderer.gameObject.name.Equals("CageSprite"))
                {
                    m_CageRenderer = renderer;
                }
            }

            // Get the sphere script
            m_SphereScript = gameObject.GetComponentInChildren<SphereFreed>();

        }

        /// <summary>
        /// This method is called, when there is an trigger with an object
        /// </summary>
        /// <param name="_collision"></param>
        private void OnTriggerEnter2D(Collider2D _collision)
        {
            if (_collision.gameObject.tag == "Player")
            {
                // If the cage is not fully broken
                if (m_CageStage > 0)
                {
                    // Change CageStage
                    m_CageStage--;

                    // Change to the new stage
                    ChangeCageStage(m_CageStage);
                }
            }
        }

        /// <summary>
        /// This method chages the stage of the cage
        /// </summary>
        /// <param name="_newStage">The next stage for the cage</param>
        public void ChangeCageStage(int _newStage)
        {
            switch (_newStage)
            {
                case 0:
                    // Make the sprite for the cage disapear
                    m_CageRenderer.enabled = false;
                    m_SphereScript.gameObject.GetComponent<CircleCollider2D>().enabled = false;

                    // Start the sphere rise process 
                    m_SphereScript.RiseSphere();

                    GameObject sceneController = GameObject.FindGameObjectWithTag("GameController");

                    // Add saved sphere to statistics
                    if (sceneController.GetComponent<Level_Stats>() != null)
                    {
                        sceneController.GetComponent<Level_Stats>().AddSavedSphere();
                
                    }
                    else
                    {
                        Debug.Log("No Level stats found");
                    }

                    //OnSphereFreed();

                    break;


                case 1:
                    // Change the sprite to broken
                    m_CageRenderer.sprite = m_CageBroken;
                    break;

                default:
                    // If the stage number is invalid
                    Debug.Log("Invalid cage stage");
                    break;

            }
            
            
        }

        //public void OnSphereFreed()
        //{
        //    if(SphereFreed != null)
        //    {
        //        SphereFreed(true);
        //    }
        //}
    }

}
