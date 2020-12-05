using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEController : MonoBehaviour
{
    [SerializeField]
    float timeLeft = 20f;
    public List<GameObject> activeQTEs;

    public GameObject qteSliderPrefab;
    public GameObject qteClickPrefab;
    public GameObject qteTouchPrefab;

    public float wantedTimeToDie = 2f;

    public int multiplier = 1;
    public int score = 0;

    public float wantedTimeQTE = 1f;
    public float timeBeforeQte = 1f;

    public enum QTEType
    {
        SLIDER,
        CLICK,
        TOUCH
    }

    private void Update()
    {
        timeBeforeQte -= Time.deltaTime;
        if (timeBeforeQte <= 0)
        {
            SpawnQTE();
            timeBeforeQte = wantedTimeQTE;
        }
    }

    public void SpawnQTE()
    {
        System.Random rdm = new System.Random();
        int rng = rdm.Next(1, 101);

        if (activeQTEs.Count == 0)
        {
            if (rng <= 80)
                createQTE(QTEType.SLIDER);
            else if (rng <= 90)
                createQTE(QTEType.TOUCH);
            else
                createQTE(QTEType.CLICK);
        }

        else
        {
            if (rng <= 20)
                createQTE(QTEType.SLIDER);
            else if (rng <= 60)
                createQTE(QTEType.TOUCH);
            else
                createQTE(QTEType.CLICK);
        }
    }

    public void createQTE(QTEType type)
    {
        switch(type)
        {
            case QTEType.SLIDER:
                activeQTEs.Add(Instantiate(qteSliderPrefab));
                break;
            case QTEType.CLICK:
                activeQTEs.Add(Instantiate(qteClickPrefab));
                break;
            case QTEType.TOUCH:
                activeQTEs.Add(Instantiate(qteTouchPrefab));
                break;
        }
    }

    public void ValidateAQTE(QTEMother qt, QTEMother.ValidationType type)
    {
        switch(type)
        {
            case QTEMother.ValidationType.PERFECT:
                score += qt.givenScore * multiplier;
                timeLeft += 2f;
                break;
            case QTEMother.ValidationType.GOOD:
                score += (qt.givenScore / 2) * multiplier;
                timeLeft += 1f;
                break;
            case QTEMother.ValidationType.FAIL:
                timeLeft -= 1f;
                break;
        }

        activeQTEs.Remove(qt.gameObject);
        Destroy(qt.gameObject);
    }
}
