using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{
    [SerializeField] Language languageToSet;
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        Localization.Instance.SetLanguage(languageToSet);
    }
}
