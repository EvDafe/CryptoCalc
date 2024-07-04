using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Languages
{
    Russian = 0,
    English = 1,
}

public enum TextKeys
{
    Settings
}

public class LanguagesContainer : MonoBehaviour
{
    private static Languages gameLanguage = Languages.Russian;
    public static Languages GameLanguage => gameLanguage;
    public Dictionary<Languages, Dictionary<TextKeys, string>> WordsDictionary { get; private set; }
    public UnityEvent LanguageChanged;

    private void Awake() =>
        FillWordsDictionary();

    public void ChangeLanguage(Languages language)
    {
        gameLanguage = language;
        LanguageChanged?.Invoke();
    }

    public void SetToRussian() =>
        ChangeLanguage(Languages.Russian);

    public void SetToEnglish() =>
        ChangeLanguage(Languages.English);


    private void FillWordsDictionary()
    {
        WordsDictionary = new Dictionary<Languages, Dictionary<TextKeys, string>>()
        {
            [Languages.Russian] = new Dictionary<TextKeys, string>()
            {


            },

            [Languages.English] = new Dictionary<TextKeys, string>()
            {

            }
        };
    }
}



