using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using TMPro;
using System;

public class PlayFabLeaderboard : MonoBehaviour
{
    [SerializeField]
    public GameObject _rowPrefab;
    [SerializeField]
    public Transform _rowsParent;

    private void Start()
    {
        Login();
    }

    private void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = PlayerPrefs.GetString("Name"),
            CreateAccount = true,
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnErrorLogin);
    }

    private void OnErrorLogin(PlayFabError obj)
    {
        Debug.Log("Error login");
    }

    private void OnSuccess(LoginResult result)
    {
        Debug.Log("Login Success");
        SendLeaderBoard(PlayerPrefs.GetInt("BestScore"));
        SubmitName();
    }

    private void SubmitName()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = PlayerPrefs.GetString("Name")
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnErrorSubmitName);
    }

    private void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {

    }

    private void OnErrorSubmitName(PlayFabError error)
    {
        Debug.Log("Error submit name");
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
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnErrorSubmitName);
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
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnErrorGetLeaderboard);
    }

    private void OnErrorGetLeaderboard(PlayFabError obj)
    {
        Debug.Log("Error get leaderboard");
    }

    private void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        foreach(Transform item in _rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            GameObject gameObject = Instantiate(_rowPrefab, _rowsParent);
            TMP_Text[] texts = gameObject.GetComponentsInChildren<TMP_Text>();
            texts[0].text = (item.Position +1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }
}
