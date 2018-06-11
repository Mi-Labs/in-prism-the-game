using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//embeds the whole class with all subproperties in the inspector
[System.Serializable]

public class ColorToPreFab
{
    //public field (Holds selected color)
    public Color32 colorPreFab;
  
    //public field (Holds the PreFab, thats assigned to the color)
    public GameObject PreFab;

}
