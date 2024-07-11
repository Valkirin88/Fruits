using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocalizationChanger : MonoBehaviour
{
    [SerializeField]
    private Button _languageButton;


    private void Start()
    {
        _languageButton.onClick.AddListener(ChangeLanguage);
    }

    private void ChangeLanguage()
    {
        LocalizationSettings.SelectedLocale = GetNextLocale(LocalizationSettings.AvailableLocales.Locales.ToArray(), LocalizationSettings.SelectedLocale);
    }

    private Locale GetNextLocale(Locale[] availableLocales, Locale currentLocale)
    {
        for (int i = 0; i < availableLocales.Length; i++)
        {
            if (availableLocales[i].Identifier == currentLocale.Identifier)
            {
                int nextIndex = (i + 1) % availableLocales.Length;
                return availableLocales[nextIndex];
            }
        }
        return currentLocale;
    }

    private void OnDestroy()
    {
        _languageButton.onClick.RemoveListener(ChangeLanguage);
    }
}
