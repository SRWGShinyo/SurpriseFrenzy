using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaxScore : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = GameController.activeGC.maxScore.ToString();
    }
}
