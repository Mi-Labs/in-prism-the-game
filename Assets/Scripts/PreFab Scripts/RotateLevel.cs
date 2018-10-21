
using UnityEngine;

public class RotateLevel : MonoBehaviour {

    public float m_RotationStep;


    private GameObject m_Level;

	// Use this for initialization
	void Start ()
    {
        m_Level = gameObject;	
	}

    public void RotateOnDegree(float degree)
    {
        m_Level.transform.Rotate(0.0f, 0.0f, degree);
    }

    public void RotateWithValue()
    {
        RotateOnDegree(m_RotationStep);
    }


}
