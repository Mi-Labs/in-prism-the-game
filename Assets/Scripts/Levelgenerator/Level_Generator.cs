using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Generator : MonoBehaviour {

    //public field (Holds map of the level)
    public Texture2D levelmap;

    //public field (Holds array with all ColorToPrefab assigments)
    public ColorToPreFab[] colorassignment;

	// Use this for initialization
	void Start ()
    {
        GenerateLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// This method generates the level by iterating over all pixels
    /// </summary>
    private void GenerateLevel()
    {
        // Iterate over every pixel in the levelmap
        for(int x =0; x < levelmap.width; x++)
        {
            for(int y=0; y < levelmap.height;y++)
            {
                GenerateObjects(x, y);
            }
        }
    }
    /// <summary>
    /// This method generates objects out of prefabs at the given position
    /// </summary>
    /// <param name="x">The x-coordinate of the object</param>
    /// <param name="y">The y-coordinate of the object</param>
    private void GenerateObjects(int x, int y)
    {
        // Get the color of every pixel
        Color pixelcolor = levelmap.GetPixel(x, y);

        //Transform the color into color32 (better readability)
        Color32 pixelcolor32 = pixelcolor;

        //if there is no alpha -> do nothing
        if(pixelcolor32.a == 0)
        {
            return;
        }
        //for every assigend color in colorassignment, create gameobject
        foreach(ColorToPreFab color in colorassignment)
        {
            if(color.colorPreFab.Equals(pixelcolor32))
            {
                //Hold actual position of found pixel
                Vector2 position = new Vector2(x, y);

                // Clone the Prefab at the actual position with no changes in transform and rotation
                Instantiate(color.PreFab, position, Quaternion.identity, transform);
            }
        }
    }
}
