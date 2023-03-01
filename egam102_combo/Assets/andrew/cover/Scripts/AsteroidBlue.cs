using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBlue : MonoBehaviour
{
    //VARIABLES
    //public GameObject score; 

    //public ScoreScript      scoreScript; 

    public GameObject mediumAsteroidPrefab;
    
    public Rigidbody2D asteroidRigidbody2D;

    public float            speed;

    public int              scoreValue;

    public ShipMovementAnimated Player;

    public GameObject pow;
    public EgamMicrogameInstance microgameInstance;


    void Awake()
    {
        Player = GameObject.Find("Player").GetComponent<ShipMovementAnimated>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "Bad")
        {
            Debug.Log("yeah this works");
            Player.gameend = true;
            Player.final = true;
            pow.SetActive(true);
            microgameInstance.LoseGame();
            //fail.WinLose = Lose;


            //Set GameOver Text & button to active
            //Instantiate(GameObject.Find("Sortero__Mission_Failed"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }


        if (collison.gameObject.tag == "Wall")
        {
            Debug.Log("yeah this works");
            Player.gameend = true;
            microgameInstance.WinGame();
            //fail.WinLose = Lose;


            //Set GameOver Text & button to active
            //Instantiate(GameObject.Find("Sortero__Mission_Failed"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }


}
