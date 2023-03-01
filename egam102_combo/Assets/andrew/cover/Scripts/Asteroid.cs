using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public float            speed;
    public float            finaly;
    public Transform player;
    public Sprite RockIMG;
    public Sprite FruitIMG;
    public bool dietag;
    public int controlselect;

    private void Awake()
    {
        controlselect = UnityEngine.Random.Range(0, 3);

        if (controlselect == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = RockIMG;
            dietag = true;
            gameObject.tag = "Bad";
        }

        if (controlselect == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = FruitIMG;
            dietag = false;
        }

        if (controlselect == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = FruitIMG;
            dietag = false;
        }

        if (controlselect == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = FruitIMG;
            dietag = false;
        }
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "Good")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.position.y > finaly) 
            { 
                transform.position = new Vector3(player.position.x, player.position.y - speed, 0); // Camera follows the player but 6 to the right
            }
    }
}
