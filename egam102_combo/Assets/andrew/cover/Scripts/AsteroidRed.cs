using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRed : MonoBehaviour
{
    //VARIABLES
    //public GameObject score; 
    
    //public ScoreScript      scoreScript; 

    public Rigidbody2D asteroidRigidbody2D;

    public float speed;
    public float asteroidHP;
    public float asteroidDMG;
    public int asteroidScore;
    public EXP_ShipMovement player;
    public RandomNumGenerator score;
    public SpriteRenderer AssIMG;
    public Sprite AllyIMG;
    private GameObject playerkill;

    public int              scoreValue;


    void Awake()
    {
        AssIMG = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent <EXP_ShipMovement>();
        score = GameObject.Find("Current #").GetComponent<RandomNumGenerator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //scoreScript = score.GetComponent<ScoreScript>();
        this.transform.Rotate(0,0,Random.Range(0, 360));
        asteroidRigidbody2D.AddForce(this.transform.up * speed);    
    }

    // Update is called once per frame
    void Update()
    {
        if (asteroidHP == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = AllyIMG;
        }
    }
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if ((collison.gameObject.tag == "Player") && (asteroidHP > 0))
        {
            Debug.Log("yeah this works");
            Destroy(GameObject.Find("Player"));
            player.playerkill.SetActive(true);
            //Set GameOver Text & button to active
            //Instantiate(GameObject.Find("Sortero__Mission_Failed"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        if (collison.gameObject.tag == "Player" && asteroidHP < 0.0001)
        {
            player.currentwater = player.maxwater;
            Destroy(this.gameObject);
            score.randomNumber = score.randomNumber + asteroidScore;
        }
        //If the asteroid crashes into wall, add force in opposite direction!
        if (collison.gameObject.tag == "Wall")
        {
            asteroidRigidbody2D.AddForce((transform.up * -1) * speed);
        }
        //If asteroid hits bullet, destroy and spawn two smaller asteroids
        if ((collison.gameObject.tag == "Bullet") && (asteroidHP > 0))
        {
            asteroidHP = asteroidHP - asteroidDMG;
        }
    }

}
