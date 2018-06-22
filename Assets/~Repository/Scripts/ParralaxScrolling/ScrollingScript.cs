using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScrollingScript : MonoBehaviour {

    public Vector2 m_speed = new Vector2(10.0f, 10.0f);

    public Vector2 m_direction = new Vector2(-1, 0);

    public bool m_isLinkedToCamera = false;

    public bool m_isLooping = false;

    private List<SpriteRenderer> m_backgroundParts;


	// Use this for initialization
	void Start ()
    {
	    if(m_isLooping)
        {
            m_backgroundParts = new List<SpriteRenderer>();

            for(int i=0;i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                SpriteRenderer renderer = child.GetComponent<SpriteRenderer>();

                if(renderer != null)
                {
                    m_backgroundParts.Add(renderer);
                }
            }

            m_backgroundParts = m_backgroundParts.OrderBy(t => t.transform.position.x).ToList();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 movement = new Vector3(m_speed.x * m_direction.x, m_speed.y * m_direction.y, 0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        if(m_isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }

        if(m_isLooping)
        {
            SpriteRenderer firstChild = m_backgroundParts.FirstOrDefault();

            if(firstChild !=null)
            {

                if(firstChild.transform.position.x < Camera.main.transform.position.x)
                {
                    if(firstChild.IsVisibleFrom(Camera.main) == false)
                    {
                        SpriteRenderer lastChild = m_backgroundParts.LastOrDefault();
                        Vector3 lastPosition = lastChild.transform.position;
                        Vector3 lastSize = (lastChild.bounds.max - lastChild.bounds.min);


                        firstChild.transform.position = new Vector3(lastPosition.x + lastSize.x, firstChild.transform.position.y, firstChild.transform.position.z);

                        m_backgroundParts.Remove(firstChild);
                        m_backgroundParts.Add(firstChild);
                    }
                }
            }
        }




	}
}
