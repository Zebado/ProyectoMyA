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

    private static Localization _instance;
    public static Localization Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Localization>();

                if (_instance == null)
                {
                    GameObject localizationObject = new GameObject(typeof(Localization).Name);
                    _instance = localizationObject.AddComponent<Localization>();
                    DontDestroyOnLoad(localizationObject);
                }
            }
            return _instance;
        }
    }

    [SerializeField] string _webURL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTasgbIF7L3PGbDRN80dZbeOeBCnAWFLz7sphsxP5RTlzxeybtqHAnV3kJKn4LgDOzByCML-0JVhOp0/pub?output=csv";

    [SerializeField] Language _currentLang;

    Dictionary<Language, Dictionary<string, string>> _languageCodex;

    public event Action onUpdate = delegate { };

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            LoadLanguage();
            StartCoroutine(DownloadCSV(_webURL));
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        StartCoroutine(DownloadCSV(_webURL));
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
    public void SetLanguage(Language newLanguage)
    {
        _currentLang = newLanguage;
        SaveLanguage();
        onUpdate();
    }

    private void SaveLanguage()
    {
        PlayerPrefs.SetInt("SelectedLanguage", (int)_currentLang);
        PlayerPrefs.Save();
    }
    private void LoadLanguage()
    {
        if (PlayerPrefs.HasKey("SelectedLanguage"))
        {
            _currentLang = (Language)PlayerPrefs.GetInt("SelectedLanguage");
        }
    }
}
