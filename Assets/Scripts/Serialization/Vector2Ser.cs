using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vector2Ser
{
    public float x;
    public float y;

    public Vector2Ser(Vector2 _vector)
    {
        x = _vector.x;
        y = _vector.y;
    }

    public Vector2 GetVector2()
    {
        return new Vector2(x, y);
    }
	
}
