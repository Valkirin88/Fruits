using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using TMPro;


public class PlayFabLeaderboard : MonoBehaviour
{
    [SerializeField]
    public GameObject _rowPrefab;
    [SerializeField]
    public Transform _rowsParent;
    [SerializeField]
    public TMP_Text _positionText;
    [SerializeField]
    public TMP_Text _nameText;
    [SerializeField]
    public TMP_Text _scoreText;

    [SerializeField]
    private GameObject _noServerConnectionObject;

    private int _maxNameLength = 11;

    private void Start()
    {
        Login();
        _scoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        var name = PlayerPrefs.GetString("Name");
        if (name.Length > _maxNameLength)
        {
            _nameText.text = name.Substring(0, _maxNameLength);
        }
        else
            _nameText.text = name;
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
       
        var requestTwo = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Fruits",
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
        foreach(Transform item in _rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            GameObject gameObject = Instantiate(_rowPrefab, _rowsParent);
            TMP_Text[] texts = gameObject.GetComponentsInChildren<TMP_Text>();
            texts[0].text = (item.Position +1).ToString();
            var name = item.DisplayName;
            if (name.Length > _maxNameLength)
            {
                texts[1].text = name.Substring(0, _maxNameLength) + "...";
            }
            else
                texts[1].text = name;
            texts[2].text = item.StatValue.ToString();
        }
    }
}
