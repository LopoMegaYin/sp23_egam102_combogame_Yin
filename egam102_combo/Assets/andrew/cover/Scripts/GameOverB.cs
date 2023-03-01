using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverB : MonoBehaviour
{
    public GameObject Failstate1;
    public GameObject Failstate2;
    public Rigidbody2D killWallBlue;
   
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "AsteroidR")
        {
            Failstate1.SetActive(true);
            Failstate2.SetActive(true);
        }
    }
}
