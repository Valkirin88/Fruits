using PlayFab.ClientModels;
using PlayFab;
using System.Collections.Generic;
using UnityEngine;

public class PlayFabGame : MonoBehaviour
{
    private GameCanvas _gameCanvas;

    public void Initialize(GameCanvas gameCanvas)
    {
        _gameCanvas = gameCanvas;
        _gameCanvas.OnGameOverShowd += UpdateLeaderboard;
        Login();
    }


    private void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    private void OnSuccess(LoginResult result)
    {
        Debug.Log("PlayFab login success");
    }

    private void OnError(PlayFabError error)
    {
        Debug.Log("Error");
    }

    private void UpdateLeaderboard()
    {
        SendLeaderBoard(GameInfo.Score);
    }

    public void SendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = GameInfo.PlayFabTableName,
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
    }

    private void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Leaderbord successfully sent");
    }
}
