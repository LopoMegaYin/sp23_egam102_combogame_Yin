using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementAnimated : MonoBehaviour
{
    public int speed;
    public bool gameend;
    public bool final;
    public Sprite DeadIMG;
    public Sprite FineIMG;

    public Transform player;

    private void Update()
    {
            if (Input.GetKeyUp(KeyCode.LeftArrow) && player.position.x == 1 && gameend == false)
            {
                player.transform.position = new Vector3(-1, player.position.y, 0);
                speed = 1;
            }
            
            if (Input.GetKeyUp(KeyCode.RightArrow) && player.position.x == 1 && gameend == false)
            {
                player.transform.position = new Vector3(3, player.position.y, 0);
                speed = 3;
            }

            if (Input.GetKeyUp(KeyCode.RightArrow) && player.position.x == -1 && gameend == false)
            {
                player.transform.position = new Vector3(1, player.position.y, 0);
                speed = 2;
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow) && player.position.x == 3 && gameend == false)
            {
                player.transform.position = new Vector3(1, player.position.y, 0);
                speed = 2;
            }

            if (gameend == true && final == true)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = DeadIMG;
            }
    }
    public void FixedUpdate()
    {
       
    }

}

