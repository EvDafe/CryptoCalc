using System.Collections.Generic;
using UnityEngine;

public class DisabledTextShower
{
    public List<GameObject> _allTexts = new();

    private Queue<int> _indexesOfDisabled;

    public void DisableEnabledText()
    {
        _indexesOfDisabled = new();
        for(int i = 0; i < _allTexts.Count; i++)
        {
            if (!_allTexts[i].activeSelf) continue;
            _indexesOfDisabled.Enqueue(i);
            _allTexts[i].SetActive(false);
        }
    }

    public void EnableEarlyDisabledText()
    {
        while (_indexesOfDisabled.Count != 0)
            _allTexts[_indexesOfDisabled.Dequeue()].SetActive(true);
    }
}
