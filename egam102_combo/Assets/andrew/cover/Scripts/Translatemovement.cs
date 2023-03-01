using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translatemovement : MonoBehaviour
{

    public float speed;

    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement ()
    {
        //Set our direction to the value of our controller axes!
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        //Move the game obj!
        this.transform.Translate(direction * speed * Time.deltaTime);
    }
}
