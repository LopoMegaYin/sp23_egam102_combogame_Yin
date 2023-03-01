using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialswap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collison)
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
            //GetComponent<Collider2D>().sharedMaterial.friction = 6;
        //}

        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<Collider2D>().sharedMaterial.friction = 0;
        }
    }
}
