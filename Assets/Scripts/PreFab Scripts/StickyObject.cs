using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyObject : MonoBehaviour {

    public float m_BreakForce;

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        Debug.Log("Found collison with:" + _collision.gameObject.name);
        if(_collision.transform.position.y - gameObject.transform.position.y >0.0f)
        {
            Debug.Log("Hit form above");
        }

        SpringJoint2D joint = gameObject.AddComponent<SpringJoint2D>();

        joint.connectedBody = _collision.gameObject.GetComponent<Rigidbody2D>();
        joint.breakForce = m_BreakForce;
    }

}
