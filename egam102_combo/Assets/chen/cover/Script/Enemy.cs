using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public EgamMicrogameInstance microgameInstance;

    private Animator animator;

    private int dir = -1;

    private float startPosX;

    private bool isDie = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        startPosX =transform.position.x; 
        
    }

    // Update is called once per frame
    void Update()
    {
     if (isDie)
     {
            return;
        
     } 
     transform.Translate(transform.right * Time.deltaTime * 0.8f * dir);

     if (transform.position.x > startPosX + 2f)
        {
            dir = dir * -1;
        }

     else if(transform.position.x < startPosX -3.7f)
        {
            dir = dir * -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ground")
        {
            dir = dir * -1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            AudioManager.instance.Play("hit");
            animator.SetTrigger("Die");
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.0387F, 0);
            isDie = true;
            
            
            Invoke("OnWinCondition", 0.01f);
            AudioManager.instance.Play("finish");
            Invoke("GameOver", 4);



            BoxCollider2D[] collider2Ds;
            collider2Ds = GetComponents<BoxCollider2D>();
            
            foreach(var item in collider2Ds)
            {
                Destroy(item);

            }
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(gameObject, 3.5f);
            
        }
    }
    public void OnWinCondition()
    {
        // Edit from Chad
        // You had a warning in the Unity Console
        // This was previously onnly one "=" sign
        // Get into the habit of fixing warnings and errors!
        if (isDie == true)
        {
            microgameInstance.WinGame();

        }


    }
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
