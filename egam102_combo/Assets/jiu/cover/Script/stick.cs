using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour
{
    public Rigidbody2D stickRigidbody;
    public float speed;
    public float acceleration;
    public float timer;

    void Start()
    {
        timer = 0;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            stickRigidbody.AddForce(stickRigidbody.gameObject.transform.up * speed);//(this.transform.up);
            speed += acceleration * Time.deltaTime;
        }

    }
}
