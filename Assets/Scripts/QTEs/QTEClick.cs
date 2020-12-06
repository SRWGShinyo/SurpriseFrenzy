using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QTEClick : QTEMother
{
    public List<Sprite> sprites;
    public GameObject circle;
    public SpriteRenderer toChange;

    [SerializeField]
    private int BORNHEIGHT = 100;

    [SerializeField]
    private int BORNWIDHT = 100;


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
        if (circle.transform.localScale.x > 0 )
        circle.transform.localScale = new Vector3(circle.transform.localScale.x
                                            - (Time.deltaTime + Mathf.Abs((2 / originalTimeToDie) - 1) * Time.deltaTime), 
                                                  circle.transform.localScale.y 
                                            - (Time.deltaTime + Mathf.Abs((2 / originalTimeToDie) - 1) * Time.deltaTime), 
                                                  circle.transform.localScale.z 
                                            - (Time.deltaTime + Mathf.Abs((2 / originalTimeToDie) - 1) * Time.deltaTime));

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
        if (timeToDie <= 0f)
            type = ValidationType.FAIL;
        else if (timeToDie >= originalTimeToDie * 0.6f)
            type = ValidationType.FAIL;
        else if (timeToDie < (originalTimeToDie * 0.3f))
            type = ValidationType.PERFECT;

        FindObjectOfType<QTEController>().ValidateAQTE(this, type);
    }

    protected override void ChoseProperPosition()
    {
        Vector2 screenPos = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(BORNWIDHT, Screen.width - BORNWIDHT), Random.Range(BORNHEIGHT, Screen.height - BORNHEIGHT), 0));
        while(!checkAvailablePos(screenPos))
        {
            screenPos = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(BORNWIDHT, Screen.width - BORNWIDHT), Random.Range(BORNHEIGHT, Screen.height - BORNHEIGHT), 0));
        }

        transform.position = screenPos;
    }
}
