using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScript : MonoBehaviour
{
    public Rigidbody2D shipRigidbody;
    public GameObject fail;

    // Edit from Chad
    // Adding "new" here resolves the warning from Unity
    // This is because "camera" is a special Unity name
    public new Transform camera;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        shipRigidbody.AddForce(this.transform.right * speed);
    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "Player")
        {
            Debug.Log("yeah this works");
            Destroy(GameObject.Find("Player"));
            Destroy(GameObject.Find("Particle System"));
            fail.SetActive(true);
            //camera.position.x = fail.position.x;
            //Set GameOver Text & button to active
            //Instantiate(GameObject.Find("Sortero__Mission_Failed"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }

        if (collison.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
