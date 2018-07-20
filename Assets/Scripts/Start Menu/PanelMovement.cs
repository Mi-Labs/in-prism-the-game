using UnityEngine;

namespace StartMenu
{
    public class PanelMovement : MonoBehaviour
    {
        public void MovePanel(float _newXValue)
        {
            if(this.gameObject.activeSelf)
            {
                transform.position = new Vector3(_newXValue, transform.position.y, transform.position.z);
            }
            
        }
    }
}

