using UnityEngine;

public static class GameInfo 
{
    //public static int Level { get { return PlayerPrefs.GetInt("Level"); } set { PlayerPrefs.SetInt("Level", value); } }

    public static int FruitNumber;
    public static int Score;

    public static bool IsSoundOn { get; private set; } = true;

    public static float TillDeathTime { get; private set; } = 3f;

    
    private static float _tillSleepTime = 10;

    public static float TillSleepTime => _tillSleepTime; 

    public static int GetFruitNumber()
    {
        FruitNumber++;
        return FruitNumber;
    }

    public static void SwitchSound()
    {
        IsSoundOn = false;
    }
}
