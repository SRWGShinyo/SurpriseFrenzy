using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrefabEntryItem : MonoBehaviour
{
    public Image spriterender;
    public TextMeshProUGUI title;
    public TextMeshProUGUI line;

    public void INCARNATE(string titleline, string descr, Sprite sprite)
    {
        spriterender.sprite = sprite;
        title.text = titleline;
        line.text = descr;
    }
}
