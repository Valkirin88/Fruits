using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using TMPro;


public class PlayFabLeaderboard : MonoBehaviour
{
    [SerializeField]
    public GameObject _usualRowPrefab;
    [SerializeField]
    public GameObject _firstRowPrefab;
    [SerializeField]
    public GameObject _secondThirdRowPrefab;


    [SerializeField]
    public Transform _rowsParent;
    [SerializeField]
    public TMP_Text _positionText;
    [SerializeField]
    public TMP_Text _scoreText;

    [SerializeField]
    private GameObject _noServerConnectionObject;

    private void Start()
    {
        Login();
        _scoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    private void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
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
        _noServerConnectionObject.SetActive(false);
        SendLeaderBoard(PlayerPrefs.GetInt("BestScore"));
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
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnErrorLeaderboardUpdated);
    }

    private void OnErrorLeaderboardUpdated(PlayFabError obj)
    {

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
            StatisticName = GameInfo.PlayFabTableName,
            StartPosition = 0,
            MaxResultsCount = 6
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnErrorGetLeaderboard);

        var requestTwo = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = GameInfo.PlayFabTableName,
            MaxResultsCount = 1
        };

        PlayFabClientAPI.GetLeaderboardAroundPlayer(requestTwo, OnLeaderboardAroundUserGet, OnErrorGetLeaderboardAroundUser);
    }

    private void OnErrorGetLeaderboardAroundUser(PlayFabError error)
    {
        Debug.Log("get player position error");
    }

    private void OnLeaderboardAroundUserGet(GetLeaderboardAroundPlayerResult result)
    {
        _positionText.text = (result.Leaderboard[0].Position + 1).ToString();
    }

    private void OnErrorGetLeaderboard(PlayFabError obj)
    {
        Debug.Log("Error get leaderboard");
        _noServerConnectionObject.SetActive(true);
    }

    private void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        var rowNumber = 0;
        foreach (Transform item in _rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            rowNumber++;
            GameObject gameObject = InstantiateRow(rowNumber);
            TMP_Text[] texts = gameObject.GetComponentsInChildren<TMP_Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.StatValue.ToString();
        }
    }

    private GameObject InstantiateRow(int number)
    {
        GameObject gameObject = new GameObject();
        if (number == 1)
        {
             gameObject = Instantiate(_firstRowPrefab, _rowsParent);
        }
        else if (number == 2 || number == 3)
        {
            gameObject = Instantiate(_secondThirdRowPrefab, _rowsParent);
        }
        else
        {
            gameObject = Instantiate(_usualRowPrefab, _rowsParent);
        }
        return gameObject;
    }
}
