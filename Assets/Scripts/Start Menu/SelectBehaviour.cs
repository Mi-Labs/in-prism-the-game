using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace StartMenu
{
    public class SelectBehaviour : MonoBehaviour
    {
        private Button m_Button;
        

        // Use this for initialization
        void Start()
        {
            gameObject.GetComponent<Button>();
        }

        // Update is called once per frame
        void Update()
        {
           if(Input.GetKey(KeyCode.RightArrow))
            {
                m_Button.FindSelectableOnRight();
            }

        }
        
        
    }
}

