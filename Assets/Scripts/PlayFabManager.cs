using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class PlayFabManager : MonoBehaviour
{
    //[SerializeField]
    //public GameObject _rowPrefab;
    //[SerializeField]
    //public Transform _rowsParent;

    private void Start()
    {
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
        Debug.Log("Success");
        SendLeaderBoard(PlayerPrefs.GetInt("BestScore"));
    }

    private void OnError(PlayFabError error)
    {
        Debug.Log("Error");
    }

    public void SendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Fruits",
                    Value = score
                }

            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
    }

    private void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Leaderbord successfully sent");
        GetLeaderboardRequest();
    }

    public void GetLeaderboardRequest()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Fruits",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError);
    }

    private void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
            Debug.Log(item.Position + "" + item.PlayFabId + "" + item.StatValue);
    }
}
