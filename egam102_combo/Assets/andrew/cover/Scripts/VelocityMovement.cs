using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMovement : MonoBehaviour
{
    public float speed;
    public float jumpspeed;

    public Vector2 direction;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(this.transform.up * jumpspeed);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = (direction * speed * Time.deltaTime);
        //rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime)
    }
}
