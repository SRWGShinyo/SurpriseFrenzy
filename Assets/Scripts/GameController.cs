using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum Gametype
    {
        NORMAL,
        HARD
    }

    public List<Gifts> giftsToGive = new List<Gifts>();
    public static GameController activeGC;
    public Gametype selectedDifficulty;

    private void Awake()
    {
        if (activeGC)
        {
            Destroy(gameObject);
        }
        else
        {
            activeGC = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
