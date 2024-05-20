using UnityEngine;

public static class GameInfo 
{
    public static int Level { get { return Level; } set { PlayerPrefs.SetInt("Level", value); } }
}
