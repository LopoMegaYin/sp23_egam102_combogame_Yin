using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP_ShipMovement : MonoBehaviour
{
    public Rigidbody2D shipRigidbody;

    public float speed;
    public float airturn;
    public float groundturn;
    private float torqueSpeed;
    public float currentwater;
    public float maxwater;
    public float waterloss;
    public bool playerdie;

    public GameObject sfxAudioSource;

    public AudioClip teleportSFX;
    public GameObject Winstate1;
    public GameObject Winstate2;
    public Image FillUI;
    public Bullet bulletScript;
    public GameObject bulletPrefab;
    public GameObject Ground;
    public GameObject playerkill;

    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "Wall")
        {
            torqueSpeed = groundturn;
        }

        if (collison.gameObject.tag == "Wall" && (currentwater < 0.0001))
        {
            Destroy(this.gameObject);
            playerkill.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collison)
    {
            torqueSpeed = airturn;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && (currentwater > 0))
        {
            shipRigidbody.AddForce(this.transform.up * speed);
                GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bulletScript = bulletInstance.GetComponent<Bullet>();
                bulletScript.ShootBullet(-transform.up);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            shipRigidbody.AddTorque(torqueSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            shipRigidbody.AddTorque(torqueSpeed * -1);
        }
        if (Input.GetKey(KeyCode.Tab))
        {
                   Winstate1.SetActive(true);
                   Winstate2.SetActive(true); 
        }

    }

    public void Update()
    {            
        //Script used to update Water Tank UI to match the "curentwater" variable.
        FillUI.fillAmount = (currentwater/maxwater);
        
        //When the space bar is pressed the current water decreases.
        if (Input.GetKey(KeyCode.Space) && (currentwater > 0))
        {
            currentwater = currentwater - waterloss;
        }

        //As a failsafe, if the water tank is empty and the spacebar is pressed the "currentwater" variable will be set to 0
        if (Input.GetKey(KeyCode.Space) && (currentwater < 0))
        {
            currentwater = 0;
        }

        //DEBUG: When the "R" key is pressed the water tank is completely refilled!
        if (Input.GetKey(KeyCode.R))
        {
            currentwater = maxwater;
        }

        if (playerdie == true)
        {
            playerkill.SetActive(true);
        }
    }
}

