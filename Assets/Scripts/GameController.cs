using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int maxScore = 0;

    public enum Gametype
    {
        TRAINING,
        NORMAL,
        HARD
    }

    public List<Gifts> giftsToGive = new List<Gifts>();
    public List<string> discoveredGifts = new List<string>();
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
            SaveMonitor.LoadGame();
        }
    }
}
