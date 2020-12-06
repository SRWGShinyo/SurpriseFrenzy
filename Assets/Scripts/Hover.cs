using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    float startY;
    public float amplitude;

    bool goUp;
    bool inCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (goUp && !inCoroutine)
        {
            StartCoroutine(goTo(new Vector3(transform.position.x, startY + amplitude, transform.position.z)));
        }
        else if (!goUp && !inCoroutine)
        {
            StartCoroutine(goTo(new Vector3(transform.position.x, startY - amplitude, transform.position.z)));
        }
    }

    private IEnumerator goTo(Vector3 vec)
    {
        inCoroutine = true;
        transform.DOMove(vec, 2f);
        yield return new WaitForSeconds(2f);
        goUp = !goUp;
        inCoroutine = false;
    }
}
