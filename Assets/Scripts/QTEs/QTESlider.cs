using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTESlider : QTEMother
{
    void Start()
    {
        originalTimeToDie = FindObjectOfType<QTEController>().wantedTimeToDie;
        timeToDie = FindObjectOfType<QTEController>().wantedTimeToDie;

        ChoseProperPosition();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void ChoseProperPosition()
    {
        
    }
}
