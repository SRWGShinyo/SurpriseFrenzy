using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController activeGC;
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
