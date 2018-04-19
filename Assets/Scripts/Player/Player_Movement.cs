using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    //Rigidbody Player-Object
    private Rigidbody2D rgb2D;

    //Jump-Strength
    public float jumppower;

    //acceleration for movement
    public float acceleration = 1.5f;

    //Factor for boost powerup
    public float boostfactor;

	// Use this for initialization
	void Start () {

        //Initalize Rigidbody of Player
        rgb2D = GetComponent<Rigidbody2D>();
        boostfactor = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// This function moves the player horizontally
    /// </summary>
    /// <param name="direction">This param decides, if the movment is to the left (-1) or to the right(1)</param>
    public void MovePlayer(float direction)
    {
        //Create movementVector2
        Vector2 movement = new Vector2(direction*acceleration*boostfactor, 0);

        //Add movement to Rigidbody
        rgb2D.AddForce(movement);

    }

    /// <summary>
    /// This function makes the player jump
    /// </summary>
    public void JumpPlayer()
    {
        //Create movementVector2
        Vector2 movement = new Vector2(0f, jumppower);

        //Add movement to rgb2D
        rgb2D.AddForce(movement);
    }
}
