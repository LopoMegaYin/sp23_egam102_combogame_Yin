using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchUpwards : MonoBehaviour
{
    public float launchForce = 500f; // the amount of force to apply when launching

    private Rigidbody2D rb; // the Rigidbody2D component of the object

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get the Rigidbody2D component
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // check if space button is pushed down
        {
            rb.AddForce(Vector2.up * launchForce); // launch the object upward
        }
    }
}


