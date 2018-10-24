using UnityEngine;

public class SandStormPush : MonoBehaviour {

    public int m_Force;
    

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == "Player")
        {
            // Calulate direction between positon and player
            Vector2 dir = _collision.contacts[0].point - (Vector2)transform.position;

            // Get opposite normalized vector
            dir = -dir.normalized;

            // Find rigidbody of player and apply force
            _collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * m_Force);
        }
    }
}
