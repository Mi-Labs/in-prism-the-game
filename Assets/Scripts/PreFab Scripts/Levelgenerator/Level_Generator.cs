using UnityEngine;
using ColorChange;

public class Level_Generator : MonoBehaviour {


    /* Variables */

    public bool m_Activate_SkyKillzone;

    // Holds map of the level
    [Space]
    public Texture2D levelmap;

    // Holds array with all ColorToPrefab assignments
    [Space]
    public ColorToPreFab[] colorassignment;


    /* Methods*/

    // Use this for initialization
    void Start ()
    {

    }
	
    public void LoadLevel(bool _again)
    {
        GenerateLevel();
        GenerateToppings();
        if (_again)
        {
            ApplyChanges();
        }
    }

    /// <summary>
    /// This method generates the level by iterating over all pixels
    /// </summary>
    private void GenerateLevel()
    {
        // Generate all kill zones before load any level objects
        GenerateKillZones();

        // Iterate over every pixel in the levelmap (Column after Column)
        for (int x = 0; x < levelmap.width; x++)
        {
            for (int y = 0; y < levelmap.height; y++)
            {
                // For every pixel of the levelmap generate that designated object
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

        // For every assigned color in colorassignment, create GameObject
        foreach(ColorToPreFab color in colorassignment)
        {
            if (color.PreFab.ToString() != "null")
            {
                if (color.PreFab.name == "Moving Fish" || color.PreFab.name == "Moving Fish B")
                {
                    color.PreFab.tag = "Platform";
                }
            }
            if(color.m_isActive)
            {
                if (color.colorPreFab.Equals(pixelcolor32))
                {
                    //Hold actual position of found pixel
                    Vector2 position = new Vector2(x, y);

                    // Clone the Prefab at the actual position with no changes in transform and rotation
                    Instantiate(color.PreFab, position, Quaternion.identity, transform);
                }
            }
        }
    }

    /// <summary>
    /// This method apply the changes from the save game
    /// </summary>
    public void ApplyChanges()
    {
        // Find the saved data
        WorldObjectSave wos = GameObject.FindGameObjectWithTag("LevelSave").GetComponent<WorldObjectSave>();

        // Hold the save for this level
        LevelSave actualLevel = null;

        // Search for a save for this level
        foreach(LevelSave save in wos.GetLevelSaves())
        {
            // When there is an entry for this level assign this data to actualLevel
            if(gameObject.scene.buildIndex.Equals(save.m_levelnumber))
            { 
                actualLevel = save;
                break;
            }
            break;
        }

        // If there is a saved level
        if(actualLevel != null)
        {
            Debug.Log("Levelsave found");
            // Get every object in the level and apply the colorchange to this
            foreach (Vector2Ser pos in actualLevel.m_colorChangedObjectPosition)
            {
                Vector2 position = pos.GetVector2();
                
                GameObject inLevel = Physics2D.OverlapCircle(position, 0.1f).gameObject;

                inLevel.GetComponent<Coloration>().ActivateColor();
            }
        }   
    }

    /// <summary>
    /// This method generates all toppings for the level
    /// </summary>
    private void GenerateToppings()
    {
        // Get all objects which should have a topping
        AddTopping[] toppings = gameObject.GetComponentsInChildren<AddTopping>();
        
        // Generate for all found GO a topping
        foreach(AddTopping topping in toppings)
        {
            topping.GenerateTopping();
        }
    }


    /// <summary>
    /// This script generates kill zones all around the level
    /// </summary>
    private void GenerateKillZones()
    {
        GameObject killzones = new GameObject("Kill Zones");

        killzones.transform.parent = transform;

        // Generate a killzone for every direction
        int i = 0;

        // If the sky killzone shouldn't be active
        if(!m_Activate_SkyKillzone)
        {
            i = 1;
        }

        while(i < 4)
        {
            // Generate a new killzone object
            GameObject killzone = new GameObject("Killzone");

            killzone.transform.parent =killzones.transform;

            // Position the killzone
            killzone.transform.position = KillzonePosition(i);

            // Add a BoxCollider to the killzone
            BoxCollider2D killzoneBox = killzone.AddComponent<BoxCollider2D>();

            // Resize the killzone
            killzoneBox.size = KillzoneSize(i);

            // Enable isTrigger on the collider
            killzoneBox.isTrigger = enabled;

            // Add Killzone script to it
            killzone.AddComponent<Killzone>();

            // Add tag to GO
            killzone.tag = "Killzone";

            i++;
        }
    }

  
    /// <summary>
    /// This method gives the killzone position for each direction 
    /// </summary>
    /// <param name="direction_number">Direction (N:0,S:1,E:2,W:3)</param>
    /// <returns>Vector of the killzone position</returns>
    private Vector3 KillzonePosition(int direction_number)
    {
        /*
         * Hold the vector for the killzone 
         * At start killzoneVector should be 0,0,0
         */
        Vector3 killzoneVector = Vector3.zero;

        // Switch between direction 
        switch(direction_number)
        {
            // North
            case 0:
                // Vector = Half of map width, map height +2, 0 @ z-axis
                killzoneVector = new Vector3(levelmap.width/2,levelmap.height+2,0);
                break;

            // South
            case 1:
                // Vector = half of map width, -1 (under last row), 0 @ z-axis
                killzoneVector = new Vector3(levelmap.width / 2, -1, 0);
                break;

            // East
            case 2:
                // Vector = map width +1 , half of map height, 0 @ z-axis
                killzoneVector = new Vector3(levelmap.width + 1, levelmap.height/2,0);
                break;   
            
            // West
            case 3:
                // Vector = -1 (before first column), half of map height, 0 @ z-axis
                killzoneVector = new Vector3(-1,levelmap.height/2,0);
                break;
            
            // Invalid Value
            default:
                Debug.LogError("Invalid input");
                break;
        }
        // return of the position for the killzone
        return killzoneVector;
    }

    /// <summary>
    /// This method chose the right size for the bounding box of the killzone and returns it as Vector2
    /// </summary>
    /// <param name="direction_number">Direction (N:0,S:1,E:2,W:3)</param>
    /// <returns>Vector of the size of the killzone</returns>
    private Vector2 KillzoneSize(int direction_number)
    {
        // Holds the standard value of the killzone size
        Vector2 killzoneSize = Vector2.zero;

        // if an empty cases is chosen, the next higher number is executed
        switch (direction_number)
        {
            // For Cases North and South
            case 0:           
            case 1:
                // Size is 3 times the width of the levelmap and 0.1f in height
                killzoneSize = new Vector2(levelmap.width * 3, 0.1f);
                break;

            // For Cases East and West
            case 2:
            case 3:
                // Size is 0.1f in width and 3 times the height of the levelmap
                killzoneSize = new Vector2(0.1f,levelmap.height*3);
                break;
            
            // If a case out of a range of 0-3 occurs
            default:
                Debug.LogError("Invalid input");
                break;
        }
        // return the right killZoneSize Vector2
        return killzoneSize;
    }
}
