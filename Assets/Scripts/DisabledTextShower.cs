using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisabledTextShower : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _allTexts;

    private Queue<int> _indexesOfDisabled;

    public void DisableEnabledText()
    {
        _indexesOfDisabled = new();
        for(int i = 0; i < _allTexts.Length; i++)
        {
            if (!_allTexts[i].gameObject.activeSelf) continue;
            _indexesOfDisabled.Enqueue(i);
            _allTexts[i].gameObject.SetActive(false);
        }
    }

    public void EnableEarlyDisabledText()
    {
        while (_indexesOfDisabled.Count != 0)
            _allTexts[_indexesOfDisabled.Dequeue()].gameObject.SetActive(true);
    }
}
