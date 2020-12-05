using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QTETouch : QTEMother
{
    KeyCode[] keys = 
        { KeyCode.A, KeyCode.Z, KeyCode.E, KeyCode.Q, KeyCode.S, KeyCode.D, KeyCode.W, KeyCode.X, KeyCode.C};

    string[] repr =
        {"A", "Z", "E", "Q", "S", "D", "W", "X", "C"};

    KeyCode chosenKey;

    void Start()
    {
        originalTimeToDie = FindObjectOfType<QTEController>().wantedTimeToDie;
        timeToDie = FindObjectOfType<QTEController>().wantedTimeToDie;
        System.Random rng = new System.Random();
        int foundNumber = rng.Next(0, keys.Length);
        chosenKey = keys[foundNumber];

        GetComponentInChildren<TextMeshProUGUI>().text = repr[foundNumber];

        ChoseProperPosition();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(chosenKey))
            validate();
    }

    protected override void ChoseProperPosition()
    {
        Vector2 screenPos = Camera.main.ScreenToWorldPoint(
        new Vector3(Random.Range(20, Screen.width), Random.Range(20, Screen.height), 0));
        while (!checkAvailablePos(screenPos))
        {
            screenPos = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(20, Screen.width), Random.Range(20, Screen.height), 0));
        }

        transform.position = screenPos;
    }
}
