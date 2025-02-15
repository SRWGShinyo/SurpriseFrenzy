﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTESlider : QTEMother
{
    public List<Sprite> sprites;

    [SerializeField]
    private int BORNHEIGHT = 80;

    [SerializeField]
    private int BORNWIDHT = 80;

    public ParticleSystem good;
    public ParticleSystem perfect;

    private void Awake()
    {
        ChoseProperPosition();
    }

    void Start()
    {
        originalTimeToDie = FindObjectOfType<QTEController>().wantedTimeToDie;
        timeToDie = FindObjectOfType<QTEController>().wantedTimeToDie;
        int chosenIndex = Random.Range(0, 4);
        GetComponentInChildren<SpriteRenderer>().sprite = sprites[chosenIndex];
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void validate()
    {
        ValidationType type = ValidationType.GOOD;
        if (timeToDie <= 0f)
        {
            type = ValidationType.FAIL;
            ShakeCamHandler.Shake();
        }
        else if (timeToDie >= originalTimeToDie * 0.3f)
        {
            type = ValidationType.PERFECT;
            ParticleSystem go = Instantiate(perfect);
            go.gameObject.transform.position = GetComponent<BezierCurve>().positions[GetComponent<BezierCurve>().positions.Count - 1];
        }
        else
        {
            ParticleSystem go = Instantiate(good);
            go.gameObject.transform.position = GetComponent<BezierCurve>().positions[GetComponent<BezierCurve>().positions.Count - 1];
        }
        FindObjectOfType<QTEController>().ValidateAQTE(this, type);
    }

    protected override void ChoseProperPosition()
    {
        Vector2 screenPos1 = Camera.main.ScreenToWorldPoint(
               new Vector3(Random.Range(BORNWIDHT, Screen.width - BORNWIDHT), Random.Range(BORNHEIGHT, Screen.height - BORNHEIGHT), 0));

        while(!checkAvailablePos(screenPos1))
        {
            screenPos1 = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(BORNWIDHT, Screen.width - BORNWIDHT), Random.Range(BORNHEIGHT, Screen.height - BORNHEIGHT), 0));
        }

        Vector2 screenPos2 = Camera.main.ScreenToWorldPoint(
            new Vector3(Random.Range(BORNWIDHT, Screen.width - BORNWIDHT), Random.Range(BORNHEIGHT, Screen.height - BORNHEIGHT), 0));

        while (!checkAvailablePos(screenPos2))
        {
            screenPos2 = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(BORNWIDHT, Screen.width - BORNWIDHT), Random.Range(BORNHEIGHT, Screen.height - BORNHEIGHT), 0));
        }

        Vector2 screenPos3 = Camera.main.ScreenToWorldPoint(
            new Vector3(Random.Range(BORNWIDHT, Screen.width - BORNWIDHT), Random.Range(BORNHEIGHT, Screen.height - BORNHEIGHT), 0));

        while (!checkAvailablePos(screenPos3))
        {
            screenPos3 = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(BORNWIDHT, Screen.width - BORNWIDHT), Random.Range(BORNHEIGHT, Screen.height - BORNHEIGHT), 0));
        }

        Vector2 screenPos4 = Camera.main.ScreenToWorldPoint(
            new Vector3(Random.Range(BORNWIDHT, Screen.width - BORNWIDHT), Random.Range(BORNHEIGHT, Screen.height - BORNHEIGHT), 0));

        while (!checkAvailablePos(screenPos4))
        {
            screenPos4 = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(BORNWIDHT, Screen.width - BORNWIDHT), Random.Range(BORNHEIGHT, Screen.height - BORNHEIGHT), 0));
        }

        transform.GetChild(0).transform.position = screenPos1;
        transform.GetChild(1).transform.position = screenPos2;
        transform.GetChild(2).transform.position = screenPos3;
        transform.GetChild(3).transform.position = screenPos4;
    }
}
