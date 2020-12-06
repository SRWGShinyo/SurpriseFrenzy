using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gifts", menuName = "GiftsMenu/Gifts", order = 1)]
public class Gifts : ScriptableObject
{
    public enum state
    {
        NORMAL,
        HARD,
        BOTH
    }

    public Sprite image;
    public string nam;
    public string tagline;
    public state objectState;
}
