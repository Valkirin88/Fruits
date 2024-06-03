using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderBoardCanvas : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _yourBest;
    [SerializeField]
    private Button _backButton;

    private void Start()
    {
        _backButton.onClick.AddListener(ShowMainMenu);
        _yourBest.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    private void ShowMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    private void OnDestroy()
    {
        _backButton.onClick.RemoveListener(ShowMainMenu);
    }
}

