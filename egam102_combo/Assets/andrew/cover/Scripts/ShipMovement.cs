using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Rigidbody2D shipRigidbody;

    public float speed;
    public float torqueSpeed;

    public AudioSource sfxAudioSource;

    public AudioClip teleportSFX;

    public Sprite StopIMG;
    public Sprite GoIMG;
    public Sprite finished;
    public GameObject fail;

    public GameObject particle;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shipRigidbody.AddForce(this.transform.up * speed);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = GoIMG;
            particle.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = StopIMG;
            particle.SetActive(false);
            this.GetComponent<Rigidbody2D>().drag = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collison)
    { 
        if (collison.gameObject.tag == "Bad" && Input.GetKey(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().drag = torqueSpeed;
        }

        if (collison.gameObject.tag == "Good")
        {
            speed = 0;
            Destroy(GameObject.Find("Particle System"));
        }

        if (collison.gameObject.tag == "Finish")
        {
            StopIMG = finished;
            GoIMG = finished;
            speed = 0;
            fail.SetActive(true);
        }
    }
    };
