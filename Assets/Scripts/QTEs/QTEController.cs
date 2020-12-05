using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEController : MonoBehaviour
{
    public List<GameObject> activeQTEs;

    public GameObject qteSliderPrefab;
    public GameObject qteClickPrefab;
    public GameObject qteTouchPrefab;

    public enum QTEType
    {
        SLIDER,
        CLICK,
        TOUCH
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
}
