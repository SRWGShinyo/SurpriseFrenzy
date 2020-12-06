using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveClass
{
    public int maxScore;
    public List<string> itemsFound;

    public SaveClass(int _maxScore, List<string> _itemsFound)
    {
        maxScore = _maxScore;
        itemsFound = new List<string>(_itemsFound);
    }
}
