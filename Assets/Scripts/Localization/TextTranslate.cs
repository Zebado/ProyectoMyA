using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextTranslate : MonoBehaviour
{

    [SerializeField] string _id;
    [SerializeField] Localization _localization;
    [SerializeField] TextMeshProUGUI _myText;

    private void Awake()
    {
        _localization = Localization.Instance;
        _localization.onUpdate += ChangeLanguage;              
    }
    private void Start()
    {
        if (_localization.LanguageCodex != null && _localization.LanguageCodex.ContainsKey(_localization.CurrentLanguage))
        {
            ChangeLanguage();
        }
    }
    void ChangeLanguage()
    {
        _myText.text = _localization.GetTranslate(_id);
    }
    private void OnDestroy()
    {
        _localization.onUpdate -= ChangeLanguage;
    }
}