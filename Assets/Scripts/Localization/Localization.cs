using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum Language
{
    Spanish,
    English
}

public class Localization : MonoBehaviour
{

    [SerializeField] string _webURL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTasgbIF7L3PGbDRN80dZbeOeBCnAWFLz7sphsxP5RTlzxeybtqHAnV3kJKn4LgDOzByCML-0JVhOp0/pub?output=csv";

    [SerializeField] Language _currentLang;

    Dictionary<Language, Dictionary<string, string>> _languageCodex;

    public event Action onUpdate = delegate { };

    private void Awake()
    {
        StartCoroutine(DownloadCSV(_webURL));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _currentLang = _currentLang == Language.English ? Language.Spanish : Language.English;

            onUpdate();
        }
    }

    IEnumerator DownloadCSV(string url)
    {
        var www = new UnityWebRequest(url);

        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        var result = www.downloadHandler.text;

        _languageCodex = LanguageSplit.LoadCSV(result, "web");

        onUpdate();

    }

    public string GetTranslate(string ID)
    {
        var idsDictionary = _languageCodex[_currentLang];

        idsDictionary.TryGetValue(ID, out var result);

        return result;
    }
}
