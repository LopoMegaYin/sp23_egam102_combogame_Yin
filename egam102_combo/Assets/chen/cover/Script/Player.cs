using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public EgamMicrogameInstance microgameInstance;

    private Animator animator;
    
    float timer = 0f;

    public float timeToFinish = 3;

    private bool isOnGround = false;
    private bool isDie = false;


    // Start is called before the first frame update
    void Start()
    
    
    {
        AudioManager.instance.Play("bgm");
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timeToFinish)
        {

            Invoke("GameOver", 3.5f);
            return;
            


        }

        if (isDie)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");

        if(h!=0)
        {
            transform.Translate(transform.right * Time.deltaTime * 1.5f * h);

            if (h > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            if (h < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            animator.SetBool("Run", true);

        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (isOnGround&&Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.instance.Play("jump");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 250);
            animator.SetBool("Jump", true);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("Jump", false);
            isOnGround = true;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            AudioManager.instance.Play("die");
            animator.SetTrigger("Die");
            isDie= true;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
            Destroy(GetComponent<CapsuleCollider2D>());
            Invoke("GameOver", 2.5f);
            Invoke("OnLoseCondition",0.01f);

        }
            
    }
    public void OnLoseCondition()
    {
        // Edit from Chad
        // You had a warning in the Unity Console
        // This was previously onnly one "=" sign
        // Get into the habit of fixing warnings and errors!
        if(isDie == true)
        {
            microgameInstance.LoseGame();

        }
        

    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
