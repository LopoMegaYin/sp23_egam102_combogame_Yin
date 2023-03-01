using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    public Sprite skierSprite;
    public Sprite skierFallenSprite;
    public GameObject objectToShow;
    public GameObject object2ToShow;
    public float launchForce = 500f;
    public float spinSpeed = 100.0f;
    private void Start()
    {
        objectToShow.SetActive(false); // hide the object at the start of the game
        object2ToShow.SetActive(false);
        rb = GetComponent<Rigidbody2D>(); // get the Rigidbody2D component
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spike")) // check if collided object is tagged "spike"
        {
            TriggerFunction(); // call a function to be triggered when collided with "spike"
        }
    }

    private void TriggerFunction()
    {
        // write your function code here
        Debug.Log("Collided with spike!");
        objectToShow.SetActive(true); // show the object when collided with "spike"
        object2ToShow.SetActive(true);
        GetComponent<SpriteRenderer>().sprite = skierFallenSprite;
        rb.AddForce(Vector2.up * launchForce);
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}
