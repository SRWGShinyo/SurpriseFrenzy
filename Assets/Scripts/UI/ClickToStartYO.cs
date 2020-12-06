using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToStartYO : MonoBehaviour
{
    bool isDisplayed = true;
    public SpriteRenderer filter;
    QTEController qtec;

    private void Start()
    {
        qtec = FindObjectOfType<QTEController>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isDisplayed)
        {
            StartCoroutine(LaunchGame());
        }
    }

    private IEnumerator LaunchGame()
    {
        isDisplayed = false;
        transform.DOScale(new Vector3(0, 0, 0), 1f);
        Color c = filter.color;
        while (c.a < 0.27)
        {
            c.a += 0.01f;
            filter.color = c;
            c = filter.color;
            yield return new WaitForSeconds(0.01f);
        }
        qtec.isActive = true;
    }
}
