using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasNameScreen : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _nameInputField;
    [SerializeField]
    private Button _enterButton;

    private void Start()
    {
        _enterButton.onClick.AddListener(SaveName);
    }

    private void SaveName()
    {
        if (_nameInputField.text != null)
        {
            PlayerPrefs.SetString("Name", _nameInputField.text);
            SceneManager.LoadSceneAsync(2);
        }
    }
}
