using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasUpdater : MonoBehaviour
{
    private QTEController qteC;

    [SerializeField]
    private TextMeshProUGUI giftCounter;
    [SerializeField]
    private TextMeshProUGUI chronos;
    [SerializeField]
    private TextMeshProUGUI score;



    private void Start()
    {
        qteC = FindObjectOfType<QTEController>();
    }

    // Update is called once per frame
    void Update()
    {
        giftCounter.text = " = " + qteC.giftvalidated.ToString();
        chronos.text = FormatStringChrono();
        score.text = "Score : " + qteC.score;
    }

    private string FormatStringChrono()
    {
        float time = qteC.timeLeft;
        int minutes = (int)(time / 60);
        int secondes = (int)(time - (minutes * 60));

        return string.Format("{0:00}:{1:00}", minutes, secondes);
    }
}
