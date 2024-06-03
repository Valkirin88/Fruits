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

    private string _defaultName;

    private void Start()
    {
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("Name")))
        {
            SceneManager.LoadSceneAsync(0);
        }
        else
            _enterButton.onClick.AddListener(SaveName);
    }

    private void SaveName()
    {
        if (_nameInputField.text != null)
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