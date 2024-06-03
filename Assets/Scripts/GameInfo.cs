using UnityEngine;

public static class GameInfo 
{
    public static int Level { get { return Level; } set { PlayerPrefs.SetInt("Level", value); } }

    //public static int FruitNumber  { get { return FruitNumber++; } }

    public static int FruitNumber;
    public static int Score;
        

    public static int GetFruitNumber()
    {
        FruitNumber++;
        return FruitNumber;
    }
}
