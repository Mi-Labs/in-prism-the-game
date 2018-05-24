using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyForPlayer : MonoBehaviour {

    private GameObject m_player;

	// Use this for initialization
	void Start ()
    {
        m_player = this.gameObject;	
	}
	


    private void OnCollisionEnter2D(Collision2D _collision)
    {
        Transform otherCollider = _collision.gameObject.transform;

        //  Debug.Log(this.transform.position);
        // Debug.Log(otherCollider.position);
        Vector2 stickyDirection = (Vector2)otherCollider.position - (Vector2)transform.position;
         Debug.Log(stickyDirection);

        float StickyDirectionX = stickyDirection.x;

        m_player.GetComponent<Rigidbody2D>().gravityScale = 0;

        ConstantForce2D stickyGravity = m_player.GetComponent<ConstantForce2D>();

        if(stickyGravity == null)
        {
            m_player.AddComponent<ConstantForce2D>().force = new Vector2(0.0f, -9.8f);
        }
        
        
    }

}
