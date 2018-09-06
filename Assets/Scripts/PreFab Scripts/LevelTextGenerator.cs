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

        if (_levelnumber < 7)
        {
            worldtext = "World Ocean";
        }
        else if (_levelnumber > 6 && _levelnumber < 12)
        {
            worldtext = "World Desert";
        }
        else if (_levelnumber > 11 && _levelnumber < 17)
        {
            worldtext = "World Jungle";
        }
        else if (_levelnumber > 16 && _levelnumber < 22)
        {
            worldtext = "World Forest";
        }
        else if (_levelnumber > 23 && _levelnumber < 27)
        {
            worldtext = "World Underground";
        }
        else if (_levelnumber > 26 && _levelnumber < 32)
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

        if (_levelnumber == 3 || _levelnumber == 7 || _levelnumber == 12 || _levelnumber == 17 || _levelnumber == 22 || _levelnumber == 27 || _levelnumber == 32)
        {
            levelnumber = "1";
        }
        else if (_levelnumber == 4 || _levelnumber == 8 || _levelnumber == 13 || _levelnumber == 18 || _levelnumber == 23 || _levelnumber == 28 || _levelnumber == 33)
        {
            levelnumber = "2";
        }
        else if (_levelnumber == 5 || _levelnumber == 9 || _levelnumber == 14 || _levelnumber == 19 || _levelnumber == 24 || _levelnumber == 29 || _levelnumber == 34)
        {
            levelnumber = "3";
        }
        else if (_levelnumber == 6 || _levelnumber == 10 || _levelnumber == 15 || _levelnumber == 20 || _levelnumber == 25 || _levelnumber == 30 || _levelnumber == 35)
        {
            levelnumber = "4";
        }
        else if (_levelnumber == 11 || _levelnumber == 16 || _levelnumber == 21 || _levelnumber == 26 || _levelnumber == 31 || _levelnumber == 36)
        {
            levelnumber = "5";
        }
        else if(_levelnumber == 37)
        {
            levelnumber = "6";
        }
        else if(_levelnumber == 38)
        {
            levelnumber = "7";
        }
           
        return "Level " + levelnumber;
    }


}
