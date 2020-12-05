using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollowMouse : MonoBehaviour
{
    [SerializeField]
    private Transform routes;
    private BezierCurve routeCurve;
    private float tParam;

    private Stack<Vector2> positionsPast = new Stack<Vector2>();

    private Vector2 sliderPosition;
    private float speedModifier;

    private bool coroutineAllowed;

    private bool isEngaged;

    public float minimalDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = routes.GetChild(0).position;
        routeCurve = routes.GetComponent<BezierCurve>();

        tParam = 0f;
        speedModifier = 0.5f;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isEngaged)
        {
            Vector2 mousePosToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (checkForMinimalDistance(mousePosToWorld, transform.position))
            {
                isEngaged = true;
            }
        }

        if (Input.GetMouseButton(0) && isEngaged)
        {
            Vector2 mousePosToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 position = FindNearestPoint(mousePosToWorld);
            if (position.z == -1)
            {
                isEngaged = false;
                return;
            }

            else
            {
                transform.position = position;
                if (!positionsPast.Contains(position))
                    positionsPast.Push(position);
            }
        }

        if (Input.GetMouseButtonUp(0) && isEngaged)
        {
            isEngaged = false;
            if (checkForMinimalDistance(transform.position, routeCurve.positions[routeCurve.positions.Count - 1], 0.8f))
            {
                positionsPast.Clear();
                GetComponentInParent<QTEMother>().validate();
            }
        }

        if (checkForMinimalDistance(transform.position, routeCurve.positions[routeCurve.positions.Count - 1], 0.8f))
        {
            positionsPast.Clear();
            GetComponentInParent<QTEMother>().validate();
        }

        if (!isEngaged && positionsPast.Count > 0)
        {
            Vector2 pos = positionsPast.Pop();
            transform.position = pos;
        }
    }

    private Vector3 FindNearestPoint(Vector2 pos1)
    {
        Vector3 pos = new Vector3(0,0,-1);
        float keepdist = Mathf.Infinity;
        foreach (Vector2 pos2 in routeCurve.positions)
        {
            float dist = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(pos1.x - pos2.x, 2) + Mathf.Pow(pos1.y - pos2.y, 2)));
            if (dist < keepdist && dist <= minimalDistance)
            {
                keepdist = dist;
                pos = pos2;
            }
        }

        return pos;
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector2 p0 = routes.GetChild(0).position;
        Vector2 p1 = routes.GetChild(1).position;
        Vector2 p2 = routes.GetChild(2).position;
        Vector2 p3 = routes.GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;
            sliderPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

            transform.position = sliderPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;
        coroutineAllowed = true;
    }

    private bool checkForMinimalDistance(Vector2 pos1, Vector2 pos2, float customPos = -1)
    {
        float localminimalDistance = customPos == -1 ? minimalDistance : customPos;
        float dist = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(pos1.x - pos2.x, 2) + Mathf.Pow(pos1.y - pos2.y, 2)));
        if (dist <= localminimalDistance)
            return true;
        return false;
    }
}
