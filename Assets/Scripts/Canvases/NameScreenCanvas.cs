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

    private int _maxNameLength = 11;

    private void Start()
    {
        _nameInputField.characterLimit = _maxNameLength;
        _soundButton.onClick.AddListener(SwitchSound);

        if (PlayerPrefs.GetString("Version") != Application.version)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("Version", Application.version);
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
