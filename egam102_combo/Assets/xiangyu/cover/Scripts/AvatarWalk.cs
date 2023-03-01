using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarWalk : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D c2d;
    public Transform groundCheck;
    public LayerMask ground;
    public float speed;
    public float jumpforce;
    private bool Isjump, Isground;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public int jumpcount;
    // private bool isHurt;

    private Animator Anim;
    public Collider2D StandColl;//player's colliderBox

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        c2d = GetComponent<Collider2D>();
        Anim = GetComponent<Animator>();
        StandColl.enabled = true;

    }

    public void FixedUpdate()
    {
        Isground = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        Jump();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && jumpcount > 0)
        {
            Isjump = true;
            Anim.SetBool("jump", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-2, 2, 2);
            rb.velocity = new Vector2(-speed, rb.velocity.y);

        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(2, 2, 2);
            rb.velocity = new Vector2(speed, rb.velocity.y);
            Anim.SetBool("run", true);
        }

        else
        {
            Anim.SetBool("run", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Anim.SetBool("Crouch", true);
            StandColl.enabled = false;
            speed = 0;
        }

        else if (Input.GetKeyUp(KeyCode.S))
        {
            Anim.SetBool("Crouch", false);
            StandColl.enabled = true;
            speed = 3;
        }

    }

    void Jump()
    {
        if (Isground)
        {
            jumpcount = 2;
            Anim.SetBool("fall", false);
        }

        if (Isjump && Isground)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpcount--;
            Isjump = false;
        }
        else if (Isjump && !Isground && jumpcount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpcount--;
            Isjump = false;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
            Anim.SetBool("fall", true);
            Anim.SetBool("jump", false);
        }

        else if (rb.velocity.y > 0 && Isjump == false)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ж��Ƿ���������
        if (collision.gameObject.tag == "Enemy")
        {
            //�������
            XiangyuEnemy enemy = collision.gameObject.GetComponent<XiangyuEnemy>();//��õ��˸�������
            if (Anim.GetBool("fall"))//�ж��Ƿ�������������ͷ���������
            {
                enemy.Death();//���ø��ຯ��
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                Anim.SetBool("jump", true);
            }
            //��������ڵ��˵����
            else if (transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-8, rb.velocity.y);
                // isHurt = true;
            }
            //��������ڵ��˵��ұ�
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(8, rb.velocity.y);
                // isHurt = true;
            }
        }

        if (collision.gameObject.CompareTag("Underground"))
        {
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadScene(2);
        }
    }

}