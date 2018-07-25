using UnityEngine;

public class ToggleTextCanvas : MonoBehaviour {

    private static GameObject m_Canvas;

    private void Start()
    {
        m_Canvas = gameObject;
    }

    public static void ToogleTextCanvas()
    {
        if(m_Canvas.activeSelf)
        {
            m_Canvas.SetActive(false);
        }
        else
        {
            m_Canvas.SetActive(true);
        }
     
    }
}
