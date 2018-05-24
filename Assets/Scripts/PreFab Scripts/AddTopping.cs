using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTopping : MonoBehaviour {

    public GameObject m_topping;

    private Vector2 m_castDirection;

	// Use this for initialization
	void Awake ()
    {
        m_castDirection = new Vector2(0.0f, -1.0f);

        RaycastHit2D hit = Physics2D.CircleCast(this.gameObject.transform.position, 1.0f, m_castDirection);

        if(hit.collider.gameObject.tag.Equals("Underground"))
        {
            Vector2 grounddirection=hit.transform.position - this.transform.position;
            // Debug.Log("Ground below me");

           if(!(grounddirection.y <0.0f))
            {
                Instantiate(m_topping, this.transform.position, Quaternion.identity, this.transform);
            }
            
        }
    
	}
	

}
