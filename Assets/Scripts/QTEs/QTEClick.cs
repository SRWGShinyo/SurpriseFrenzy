using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEClick : QTEMother
{
    void Start()
    {
        originalTimeToDie = FindObjectOfType<QTEController>().wantedTimeToDie;
        timeToDie = FindObjectOfType<QTEController>().wantedTimeToDie;
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform && (hit.transform.gameObject == gameObject))
            {
                validate();
            }
        }
    }

    protected override void ChoseProperPosition()
    {
    }
}
