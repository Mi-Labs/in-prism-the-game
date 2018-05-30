using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMachine : MonoBehaviour {


    public GameObject target;

    public int waittime;

    public bool hadturned;
    public bool hadwaited;
    public Rigidbody2D targetRB;
    public bool look_direction_left;

    [HideInInspector]
    public IMoveMachine currentState;

    public MoveState moveState;

    public WaitState waitState;

    public Vector2 startposition;

    public Vector2 endposition;

    void Awake()
    {
        moveState = new MoveState(this);
        waitState = new WaitState(this);
        
    }
    // Use this for initialization
    void Start ()
    {
        target = gameObject;
        targetRB = target.GetComponent<Rigidbody2D>();
        startposition = (Vector2)target.transform.position;
        endposition = FindEndpositionX();
        look_direction_left = false;
        currentState = moveState;
        hadwaited = false;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentState.UpdateState();
	}

    public Vector2 FindEndpositionX()
    {
        RaycastHit2D hit = Physics2D.Raycast(startposition, Vector2.right);
        if(hit)
        {
            return (Vector2)hit.transform.position;
        }

        return Vector2.zero;
    }

    IEnumerator WaitforSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    public void Wait()
    {
        StartCoroutine(WaitforSeconds(waittime));
        hadwaited = true;
    }
}
