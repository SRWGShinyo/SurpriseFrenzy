using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QTEClick : QTEMother
{
    public List<Sprite> sprites;
    public GameObject circle;
    public SpriteRenderer toChange;


    void Start()
    {

        timeToDie = FindObjectOfType<QTEController>().wantedTimeToDie;
        originalTimeToDie = FindObjectOfType<QTEController>().wantedTimeToDie;
        int chosenIndex = Random.Range(0, 4);
        toChange.sprite = sprites[chosenIndex];
        ChoseProperPosition();
    }

    protected override void Update()
    {
        base.Update();
        circle.transform.localScale = new Vector3(circle.transform.localScale.x - Time.deltaTime, 
                                circle.transform.localScale.y - Time.deltaTime, circle.transform.localScale.z - Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform && (hit.transform.gameObject == gameObject))
            {
                validate();
            }
        }
    }

    public override void validate()
    {
        ValidationType type = ValidationType.GOOD;
        if (timeToDie <= -0.5f)
            type = ValidationType.FAIL;
        else if (timeToDie >= originalTimeToDie * 0.75f)
            type = ValidationType.FAIL;
        else if (timeToDie < originalTimeToDie / 2f)
            type = ValidationType.PERFECT;

        FindObjectOfType<QTEController>().ValidateAQTE(this, type);
    }

    protected override void ChoseProperPosition()
    {
        Vector2 screenPos = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(80, Screen.width), Random.Range(80, Screen.height), 0));
        while(!checkAvailablePos(screenPos))
        {
            screenPos = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(80, Screen.width), Random.Range(80, Screen.height), 0));
        }

        transform.position = screenPos;
    }
}
