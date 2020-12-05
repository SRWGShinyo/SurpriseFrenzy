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
        int chosen = Random.Range(0, 3);
        if (chosen == 0)
            rb.AddForce(Vector2.up * 19, ForceMode2D.Impulse);
        else if (chosen == 1)
            rb.AddForce(Vector2.left * 19, ForceMode2D.Impulse);
        else
            rb.AddForce(Vector2.right * 19, ForceMode2D.Impulse);
    }
}
