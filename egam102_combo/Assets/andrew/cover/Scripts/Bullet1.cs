using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public Rigidbody2D bulletRigidbody;

    public float speed;
    public float lifetime;

    private void Awake()
    {
        bulletRigidbody = this.GetComponent<Rigidbody2D>();
    }

    public void ShootBullet (Vector2 direction)
    {
        //add force to bullet!
        bulletRigidbody.AddForce (direction * speed);

        //Destroy Bullet after certain ammount of secs
        Destroy(this.gameObject, lifetime);
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}