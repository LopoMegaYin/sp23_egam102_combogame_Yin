using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementRMX : MonoBehaviour
{
    public Rigidbody2D shipRigidbody;

    public float speed;
    public float torqueSpeed;


    public AudioSource sfxAudioSource;

    public AudioClip teleportSFX;

    public GameObject Winstate1;
    public GameObject Winstate2;
 
    public int controlselect;
    private void Awake()
    {
        controlselect = UnityEngine.Random.Range(0, 3);
    }
private void FixedUpdate()
    {
        if (controlselect == 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                shipRigidbody.AddForce(this.transform.up * speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                shipRigidbody.AddTorque(torqueSpeed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                shipRigidbody.AddTorque(torqueSpeed * -1);
            }
        }

        if (controlselect == 1)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                shipRigidbody.AddForce(this.transform.up * speed);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                shipRigidbody.AddTorque(torqueSpeed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                shipRigidbody.AddTorque(torqueSpeed * -1);
            }
        }

        if (controlselect == 2)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                shipRigidbody.AddForce(this.transform.up * speed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                shipRigidbody.AddTorque(torqueSpeed);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                shipRigidbody.AddTorque(torqueSpeed * -1);
            }
        }

        if (controlselect == 3)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                shipRigidbody.AddForce(this.transform.up * speed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                shipRigidbody.AddTorque(torqueSpeed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                shipRigidbody.AddTorque(torqueSpeed * -1);
            }
        }

        if (Input.GetKey(KeyCode.Tab))
    {
                   Winstate1.SetActive(true);
                   Winstate2.SetActive(true); 
        }

    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
           TeleportShip (this.transform);
        }
    }

    public void TeleportShip (Transform ship)
    {
        //Set the bounds
        //float xBounds = Random.Range(-8, 8);
        float xBounds = UnityEngine.Random.Range(-8, 8);
        //float yBounds = Random.Range(-4, 4);
        float yBounds = UnityEngine.Random.Range(-4, 4);

        //Set Teleport Position
        Vector3 teleportPos = new Vector3(xBounds, yBounds, 0);

        ship.position = new Vector3(xBounds, yBounds, 0);
        sfxAudioSource.clip = teleportSFX;
        sfxAudioSource.Play();
    }

}

