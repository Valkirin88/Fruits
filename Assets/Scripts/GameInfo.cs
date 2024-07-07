
public static class GameInfo 
{
    //public static int Level { get { return Level; } set { PlayerPrefs.SetInt("Level", value); } }

    public static int FruitNumber;
    public static int Score;

    private static bool _isSoundOn = true;

   // public static bool IsSoundOn { get { return _isSoundOn; } private set }
    public static bool IsSoundOn { get { return _isSoundOn; }}


    //private static float _timeTillDeath = 3f;
    //public static bool TimeTillDeath { get { return _timeTillDeath; } private set };

    private static float _timeTillDeath = 3f;
    private static float _tillSleepTime = 400f;

    public static float TillDeathTime  => _timeTillDeath;

    public static float TillSleepTime => _tillSleepTime; 

    public static int GetFruitNumber()
    {
        FruitNumber++;
        return FruitNumber;
    }

    public static void SwitchSound()
    {
        _isSoundOn = false;
    }
}
