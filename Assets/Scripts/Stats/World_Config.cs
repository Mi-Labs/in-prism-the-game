using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


/// <summary>
///  This class stores all values for boost and maybe some other values
///  It's for developement purpose -> you can quickly change duration and strength of powerups
/// </summary>

[System.Serializable]
public class World_Config : MonoBehaviour {

    // Holds the only instance for script
    public static World_Config instance = null;

    // Values for Boost
    [Header("Boost-Values")]
    public bool isavailableBoost;

    public int activetimeBoost = 2;

    public int cooldowntimeBoost = 10;

    public float strenghtBoost = 2.0f;

    // Space between two different parts
    [Space(20)]

    //  Values for Power-Jump
    [Header("Power-Jump-Values")]
    public int activetime_jump = 3;

    public int cooldowntime_jump = 3;

    public float extrajumppower = 2.0f;

    [Space(20)]

    // Values for Sticky
    [Header("Sticky-Values")]
    public int activetime_sticky;

    public int cooldowntime_sticky;

    [Space(20)]

    // Values for Invulnerablity
    [Header("Invulnerablity-Values")]
    public int activetime_invulnerable;

    public int cooldowntime_invulnerable;

    [Space(20)]

    // Values for Power_Light
    [Header("Power_Light-Values")]
    public int activetime_power_light;
    public int cooldowntime_power_light;

    [Space(20)]
    [Header("PreFab Timer")]
    public GameObject timer;

    // @Load of this Object -> Should never be destroyed when loaded
    private void Awake()
    {
        /* Singleton Pattern */

        // If no other instance is there -> save this instance
        if(instance == null)
        {
            instance = this;
        }

        // if another instance is already there -> destroy this
        else if(instance !=this)
        {
            Destroy(gameObject);
        }


        /* DontDestroyOnLoad */

        DontDestroyOnLoad(this);
    }

}




	
