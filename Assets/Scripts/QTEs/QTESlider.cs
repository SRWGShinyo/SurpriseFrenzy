using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTESlider : QTEMother
{
    private void Awake()
    {
        ChoseProperPosition();
    }

    void Start()
    {
        originalTimeToDie = FindObjectOfType<QTEController>().wantedTimeToDie;
        timeToDie = FindObjectOfType<QTEController>().wantedTimeToDie;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void ChoseProperPosition()
    {
        Vector2 screenPos1 = Camera.main.ScreenToWorldPoint(
               new Vector3(Random.Range(20, Screen.width), Random.Range(20, Screen.height), 0));

        while(!checkAvailablePos(screenPos1))
        {
            screenPos1 = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(20, Screen.width), Random.Range(20, Screen.height), 0));
        }

        Vector2 screenPos2 = Camera.main.ScreenToWorldPoint(
            new Vector3(Random.Range(20, Screen.width), Random.Range(20, Screen.height), 0));

        while (!checkAvailablePos(screenPos2))
        {
            screenPos2 = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(20, Screen.width), Random.Range(20, Screen.height), 0));
        }

        Vector2 screenPos3 = Camera.main.ScreenToWorldPoint(
            new Vector3(Random.Range(20, Screen.width), Random.Range(20, Screen.height), 0));

        while (!checkAvailablePos(screenPos3))
        {
            screenPos3 = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(20, Screen.width), Random.Range(20, Screen.height), 0));
        }

        Vector2 screenPos4 = Camera.main.ScreenToWorldPoint(
            new Vector3(Random.Range(20, Screen.width), Random.Range(20, Screen.height), 0));

        while (!checkAvailablePos(screenPos4))
        {
            screenPos4 = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(20, Screen.width), Random.Range(20, Screen.height), 0));
        }

        transform.GetChild(0).transform.position = screenPos1;
        transform.GetChild(1).transform.position = screenPos2;
        transform.GetChild(2).transform.position = screenPos3;
        transform.GetChild(3).transform.position = screenPos4;
    }
}
