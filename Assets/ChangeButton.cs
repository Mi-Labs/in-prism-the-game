using UnityEngine;
using UnityEngine.UI;

public class ChangeButton : MonoBehaviour {

    private Button[] m_Buttons;
    private GameObject m_Controller;

    private void Start()
    {
        m_Buttons = gameObject.GetComponentsInChildren<Button>();
        m_Controller = GameObject.FindGameObjectWithTag("GameController");
    }


    void ChooseLevel(string _input)
    {
        m_Controller.BroadcastMessage("ChooseLevel", _input);
    }

}
