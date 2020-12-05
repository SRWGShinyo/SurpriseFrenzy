using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowBoom : MonoBehaviour
{
    bool isRotating;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GoAway();
    }

    void Update()
    {
        if (isRotating)
            transform.Rotate(new Vector3(0, 0, 500 * Time.deltaTime), Space.World);
    }

    public void GoAway()
    {
        isRotating = true;
        rb.gravityScale = 2;
        rb.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
    }
}
