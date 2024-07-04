using TMPro;
using UnityEngine;
using Zenject;

public class LanguageButtonsHighlighter : MonoBehaviour
{
    [SerializeField] private TMP_Text _engButton;
    [SerializeField] private TMP_Text _ruButton;

    private LanguagesContainer _languageContainer;

    [Inject]
    private void Construst(LanguagesContainer container) =>
        _languageContainer = container;

    private void OnEnable() =>
        UpdateColor();

    private void Start()
    {
        _languageContainer.LanguageChanged.AddListener(UpdateColor);
        UpdateColor();
    }

    private void UpdateColor()
    {
        Color defaultColor = _engButton.color == Color.green ? _ruButton.color : _engButton.color;
        _engButton.color = defaultColor;
        _ruButton.color = defaultColor;
        switch (LanguagesContainer.GameLanguage)
        {
            case Languages.English:
                _engButton.color = Color.green; break;
            case Languages.Russian:
                _ruButton.color = Color.green; break;
        }
    }

}
