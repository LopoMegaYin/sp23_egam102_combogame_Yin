using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedAsteroid : MonoBehaviour
{
    //VARIABLES
    public GameObject mediumAsteroidPrefab;

    public Rigidbody2D asteroidRigidbody2D;

    public float speed;

    public AudioSource sfxAudioSource;

    public AudioClip teleportSFX;

    // Start is called before the first frame update
    void Start()
    {
        asteroidRigidbody2D = this.GetComponent<Rigidbody2D>();
        this.transform.Rotate(0, 0, Random.Range(0, 360));
        asteroidRigidbody2D.AddForce(this.transform.up * speed);
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
        //if (collison.gameObject.tag == "Player")
        //{
            //Destroy(collison.gameObject);
        //}
        //If the asteroid crashes into wall, add force in opposite direction!
        if (collison.gameObject.tag == "Wall")
        {
            asteroidRigidbody2D.AddForce((transform.up * -1) * speed);
        }
        //If asteroid hits bullet, destroy and spawn two smaller asteroids
        if (collison.gameObject.tag == "killWall")
        {
            sfxAudioSource.clip = teleportSFX;
            sfxAudioSource.Play();
            Destroy(this.gameObject);
        }
    }
}