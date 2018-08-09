using UnityEngine;

namespace Spheres
{
    public class CageBehavior : MonoBehaviour
    {

        /* Fields */

        public int m_CageStage;
        [Space(20)]
        public Sprite m_CageBroken;

        private SpriteRenderer m_CageRenderer;

        private SphereFreed m_SphereScript;
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
            m_SphereScript = gameObject.GetComponentInChildren<SphereFreed>();

        }


        private void OnTriggerEnter2D(Collider2D _collision)
        {
            if (_collision.gameObject.CompareTag("Player"))
            {
                if (m_CageStage > 0)
                {
                    m_CageStage--;
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
                    m_SphereScript.RiseSphere();

                    GameObject sceneController = GameObject.FindGameObjectWithTag("GameController");

                    if (sceneController.GetComponent<Level_Stats>() != null)
                    {
                        sceneController.GetComponent<Level_Stats>().AddSavedSphere();
                    }
                    else
                    {
                        Debug.Log("No Level stats found");
                    }
                    break;

                case 1:
                    // Change the sprite to broken
                    m_CageRenderer.sprite = m_CageBroken;
                    break;

                default:
                    Debug.Log("Invalid cage stage");
                    break;
            }
        }
    }

}
