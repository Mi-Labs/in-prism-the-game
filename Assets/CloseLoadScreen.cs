using UnityEngine;

public class CloseLoadScreen : MonoBehaviour {

    public GameObject m_Canvas;



	// Use this for initialization
	void Start ()
    {
        m_Canvas = gameObject;	
	}
	
	public void CloseCanvas()
    {
        if(m_Canvas.activeSelf)
        {
            m_Canvas.SetActive(false);
        }
    }
}
