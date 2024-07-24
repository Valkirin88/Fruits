using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameScreenCanvas : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _nameInputField;
    [SerializeField]
    private Button _enterButton;


    [SerializeField]
    private Button _soundButton;
    [SerializeField]
    private Image _soundButtonImage;
    [SerializeField]
    private Sprite _soundOnSprite;
    [SerializeField]
    private Sprite _soundOffSprite;

    private void Start()
    {
        _soundButton.onClick.AddListener(SwitchSound);
        Debug.Log(PlayerPrefs.GetString("Name"));
        Debug.Log(Application.version);
        Debug.Log(PlayerPrefs.GetString("Version"));

        if (PlayerPrefs.GetString("Version") != Application.version)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("Version", Application.version);
            Debug.Log("Delete");
            Debug.Log(Application.version);
            Debug.Log(PlayerPrefs.GetString("Version"));
        }

        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("Name")))
        {
            SceneManager.LoadSceneAsync(0);
        }
        else
            _enterButton.onClick.AddListener(SaveName);
    }

    private void SwitchSound()
    {
        ChangeSoundButtonSprite(GameInfo.SwitchSound());
    }

    private void ChangeSoundButtonSprite(bool IsSoundOn)
    {
        if (IsSoundOn)
        {
            _soundButtonImage.sprite = _soundOnSprite;
        }
        else
            _soundButtonImage.sprite = _soundOffSprite;
    }


    private void SaveName()
    {
        if (!string.IsNullOrEmpty(_nameInputField.text))
        {
            PlayerPrefs.SetString("Name", _nameInputField.text);
            SceneManager.LoadSceneAsync(0);
        }
    }

    private void OnDestroy()
    {
        _enterButton.onClick.RemoveListener(SaveName);
    }
}
