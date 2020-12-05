using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QTEMother : MonoBehaviour
{
    public enum ValidationType
    {
        PERFECT,
        GOOD,
        FAIL
    }

    public float timeToDie;
    public float originalTimeToDie;
    public int givenScore = 200;
    protected QTEMother() { }

    protected virtual void Update()
    {
        timeToDie -= Time.deltaTime;
        if (timeToDie <= -0.5f)
            validate();
    }
    public void validate()
    {
        ValidationType type = ValidationType.GOOD;
        if (timeToDie <= -0.5f)
            type = ValidationType.FAIL;
        else if (timeToDie >= originalTimeToDie * (3 / 4))
            type = ValidationType.FAIL;
        else if (timeToDie >= originalTimeToDie / 2f)
            type = ValidationType.PERFECT;

        FindObjectOfType<QTEController>().ValidateAQTE(this, type);
    }

    protected abstract void ChoseProperPosition();
}
