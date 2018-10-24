using UnityEngine;

public class MushroomPush : MonoBehaviour {

    public int m_Force;

    private Vector2 m_Direction;

	// Use this for initialization
	void Start ()
    {
        m_Direction = Vector2.up;	
	}
	
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == "Player")
        {
            // Adds ForcePush Upwards
            _collision.gameObject.GetComponent<Rigidbody2D>().AddForce(m_Force * m_Direction);
        }
    }
}
