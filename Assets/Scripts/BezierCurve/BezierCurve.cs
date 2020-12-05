using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BezierCurve : MonoBehaviour
{
    [SerializeField]
    private Transform[] controlPoints;

    [SerializeField]
    private LineRenderer render;

    public List<Vector3> positions;
    private Vector2 gizmosPosition;
    public GameObject circlewhite;

    private void Start()
    {
        positions = new List<Vector3>(getPositions());
        if (render)
        {
            render.positionCount = positions.Count;
            render.SetPositions(positions.ToArray());
        }

        GameObject end = Instantiate(circlewhite);
        end.transform.position = positions[positions.Count - 1];
        end.transform.SetParent(gameObject.transform);
    }

    private List<Vector3> getPositions()
    {
        List<Vector3> arrayPos = new List<Vector3>();
        for (float t = 0; t < 1; t += 0.0125f)
        {
           Vector3 newPos = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
                Mathf.Pow(t, 3) * controlPoints[3].position;

            arrayPos.Add(newPos);
        }
        return arrayPos;
    }

    private void OnDrawGizmos()
    {
        for (float t = 0; t < 1; t += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
                Mathf.Pow(t, 3) * controlPoints[3].position;

            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }

        Gizmos.DrawLine(new Vector2(controlPoints[0].position.x, controlPoints[0].position.y),
            new Vector2(controlPoints[1].position.x, controlPoints[1].position.y));

        Gizmos.DrawLine(new Vector2(controlPoints[2].position.x, controlPoints[2].position.y),
            new Vector2(controlPoints[3].position.x, controlPoints[3].position.y));
    }
}
