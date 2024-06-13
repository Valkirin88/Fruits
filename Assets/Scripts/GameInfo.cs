
public static class GameInfo 
{
    //public static int Level { get { return Level; } set { PlayerPrefs.SetInt("Level", value); } }

    public static int FruitNumber;
    public static int Score;

    private static bool _isSoundOn = true;

   // public static bool IsSoundOn { get { return _isSoundOn; } private set }
    public static bool IsSoundOn { get { return _isSoundOn; }}

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
