using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class enemyAI : XiangyuEnemy
{
    private Collider2D coll;
    private Rigidbody2D rb;
    public int speed;

    public Transform left, right;//��߽߱������
    private float leftMargin, rightMargin;//Frog�����ƶ������ұ߽�
    private bool faceRight = true;//��ʼ�����������ҵ�

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        //�ֱ������ұ߽�λ�õ�x��Ĵ�С
        leftMargin = left.position.x;
        rightMargin = right.position.x;
        //��ֹ��߽߱��������ƶ�����ú�ֱ������
        Destroy(left.gameObject);
        Destroy(right.gameObject);
    }

    void Update()
    {
        Movement();
    }

    //�����ƶ�
    void Movement()
    {
        //���������
        if (faceRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            //�����˳����ұ߽�ʱ
            if (transform.position.x > rightMargin)
            {
                rb.velocity = new Vector2(0, 0);
                transform.localScale = new Vector3(-1, 1, 1);
                faceRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            //������Խ����߽�ʱ
            if (transform.position.x < leftMargin)
            {
                rb.velocity = new Vector2(0, 0);
                transform.localScale = new Vector3(1, 1, 1);
                faceRight = true;
            }
        }
    }
}
