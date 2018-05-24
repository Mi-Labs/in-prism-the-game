using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyForPlayer : MonoBehaviour {

    private GameObject m_player;

    private float m_fakeGravity = 9.8f;

    public static ConstantForce2D stickyGravity = null;


    private void Awake()
    {
        m_player = this.gameObject;

        if (stickyGravity == null)
        {
           stickyGravity = m_player.AddComponent<ConstantForce2D>();
        }
    }


    private void OnCollisionEnter2D(Collision2D _collision)
    {
        stickyGravity.enabled = true;

        Transform otherCollider = _collision.gameObject.transform;

        // Debug.Log(this.transform.position);
        // Debug.Log(otherCollider.position);
        Vector2 stickyDirection = (Vector2)otherCollider.position - (Vector2)transform.position;
        Debug.Log(stickyDirection);

        float stickyDirectionX = stickyDirection.x;
        float stickyDirectionY = stickyDirection.y;

        bool isInXDirection = CheckForXDirection(stickyDirection);

        m_player.GetComponent<Rigidbody2D>().gravityScale = 0;


        if (isInXDirection)
        {
            if(stickyDirectionX < 0.0f)
            {
                stickyGravity.force = new Vector2(-m_fakeGravity, 0.0f);
            }
            else
            {
                stickyGravity.force = new Vector2(m_fakeGravity, 0.0f);
            }
        }
        else
        {
            if(stickyDirectionY < 0.0f)
            {
                stickyGravity.force = new Vector2(0.0f, -m_fakeGravity);
            }
            else
            {
                stickyGravity.force = new Vector2(0.0f, m_fakeGravity);
            }
        }

    }

    private bool CheckForXDirection(Vector2 _collisionDirection)
    {
        if (Mathf.Abs(_collisionDirection.x) > Mathf.Abs(_collisionDirection.y))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionExit2D(Collision2D _collision)
    {
        stickyGravity.force = new Vector2(0.0f, -m_fakeGravity);
    }

}
