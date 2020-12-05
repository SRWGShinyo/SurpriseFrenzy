using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static int scoreGivenNormal = 200;
    public static int scoreGivenHard = 400;

    public static int scoreGivenGiftNormal = 500;
    public static int scoreGivenGiftHard = 750;

    public static float ttlNormal = 1.5f;
    public static float ttlHard = 1.1f;

    public static float timeSpawningNormal = 0.8f;
    public static float timeSpawningHard = 0.6f;

    public static float givenTimeNormalPerfect = 1f;
    public static float givenTimeHardPerfect = 0.5f;

    public static float givenTimeNormalGood = 0.5f;
    public static float givenTimeHardGood = 0f;
}
