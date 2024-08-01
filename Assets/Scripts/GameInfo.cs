using UnityEngine;

public static class GameInfo 
{
    //public static int Level { get { return PlayerPrefs.GetInt("Level"); } set { PlayerPrefs.SetInt("Level", value); } }

    public static int Score;

    public static float InstantiationHighPosition { get; private set; } = 15f;
    public static bool IsSoundOn { get; private set; } = true;

    public static float TillDeathTime { get; private set; } = 3f;

    public static int PointsTillThousand { get; private set; } = 1000;

    public static string PlayFabTableName { get; } = "Fruits_1";

    public static float GameSpeed { get; private set; } = 1.3f;

    private static float _tillSleepTime = 200;

    public static float TillSleepTime => _tillSleepTime; 


    public static bool SwitchSound()
    {
       if(IsSoundOn == true)
        {
            IsSoundOn = false;
        }
       else 
            IsSoundOn = true;
        return IsSoundOn;
    }
}
