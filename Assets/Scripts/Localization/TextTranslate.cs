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

   void ChangeLanguage()
    {
        _myText.text = _localization.GetTranslate(_id);
    }

    private void OnDestroy()
    {
        _localization.onUpdate -= ChangeLanguage;
    }
}