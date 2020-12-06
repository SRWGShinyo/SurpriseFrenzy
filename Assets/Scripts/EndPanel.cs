using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI CadeauScore;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI record;

    public void SetUp()
    {
        QTEController qtec = FindObjectOfType<QTEController>();
        Score.text = qtec.score.ToString();
        CadeauScore.text = "x " + qtec.giftvalidated.ToString() + " = " + getGiftScore();
        finalScore.text = "Total = " + qtec.computeTotalScore();

        if (qtec.computeTotalScore() > GameController.activeGC.maxScore)
        {
            GameController.activeGC.maxScore = qtec.computeTotalScore();
            record.enabled = true;
        }
        try
        {
            SaveMonitor.Save();
        }
        catch(Exception e)
        {
            Debug.LogError("Could not save : " + e.StackTrace);
        }

    }

    private string getGiftScore()
    {
        QTEController qtec = FindObjectOfType<QTEController>();

        return (qtec.awardByGift * qtec.giftvalidated).ToString();
    }
}
