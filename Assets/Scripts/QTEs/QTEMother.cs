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
    public abstract void validate();

    public bool checkAvailablePos(Vector2 pos)
    {
        QTEController qte = FindObjectOfType<QTEController>();
        if (!qte)
        {
            Debug.LogError("ERROR: QTEController not in the scene.");
            return true;
        }

        foreach (GameObject go in qte.activeQTEs)
        {
            QTEMother qtemom = go.GetComponent<QTEMother>();
            if (qtemom is QTEClick click)
            {
                if (!checkProperDistance(click.transform.position, pos))
                    return false;
            }

            else if (qtemom is QTETouch touch)
            {
                if (!checkProperDistance(touch.transform.position, pos))
                    return false;
            }

            else if (qtemom is QTESlider slide)
            {
                BezierCurve curve = qtemom.gameObject.GetComponent<BezierCurve>();
                foreach (Vector2 v2 in curve.positions)
                    if (!checkProperDistance(pos, v2))
                        return false;
            }
        }
        return true;
    }

    private bool checkProperDistance(Vector2 vec1, Vector2 vec2, float distance = 2f)
    {
        float dist = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(vec1.x - vec2.x, 2) + Mathf.Pow(vec1.y - vec2.y, 2)));
        if (dist < distance)
            return false;

        return true;
    }

    protected abstract void ChoseProperPosition();
}
