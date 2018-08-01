using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelTextGenerator
{
    /// <summary>
    /// This method generates the level infos displayed on the panel
    /// </summary>
    /// <param name="_levelnumber"></param>
    /// <returns></returns>
    public static string GetLevelText(int _levelnumber)
    {
        string leveltext = string.Empty;
        string worldtext = string.Empty;

        if (_levelnumber < 5)
        {
            worldtext = "World Ocean";
        }
        else if (_levelnumber > 4 && _levelnumber < 10)
        {
            worldtext = "World Desert";
        }
        else if (_levelnumber > 9 && _levelnumber < 15)
        {
            worldtext = "World Jungle";
        }
        else if (_levelnumber > 14 && _levelnumber < 20)
        {
            worldtext = "World Forest";
        }
        else if (_levelnumber > 19 && _levelnumber < 25)
        {
            worldtext = "World Underground";
        }
        else if (_levelnumber > 24 && _levelnumber < 30)
        {
            worldtext = "World Vulcan";
        }
        else
        {
            worldtext = "Night World";
        }

        // Generate the level number depending on the current world
        leveltext = GenerateLevelText(_levelnumber);

        return worldtext + "\n" + leveltext;
    }

    private static string GenerateLevelText(int _levelnumber)
    {
        string levelnumber = string.Empty;

        if (_levelnumber == 1 || _levelnumber == 5 || _levelnumber == 10 || _levelnumber == 15 || _levelnumber == 20 || _levelnumber == 25)
        {
            levelnumber = "1";
        }
        else if (_levelnumber == 2 || _levelnumber == 6 || _levelnumber == 11 || _levelnumber == 16 || _levelnumber == 21 || _levelnumber == 26)
        {
            levelnumber = "2";
        }
        else if (_levelnumber == 3 || _levelnumber == 7 || _levelnumber == 12 || _levelnumber == 17 || _levelnumber == 22 || _levelnumber == 27)
        {
            levelnumber = "3";
        }
        else if (_levelnumber == 4 || _levelnumber == 8 || _levelnumber == 13 || _levelnumber == 18 || _levelnumber == 23 || _levelnumber == 28)
        {
            levelnumber = "4";
        }
        else if (_levelnumber == 9 || _levelnumber == 14 || _levelnumber == 19 || _levelnumber == 24 || _levelnumber == 29)
        {
            levelnumber = "5";
        }

        return "Level " + levelnumber;
    }


}
