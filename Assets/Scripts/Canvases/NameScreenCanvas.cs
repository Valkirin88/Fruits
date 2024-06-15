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
