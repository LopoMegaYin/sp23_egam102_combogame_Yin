using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class XiangyuEnemy : MonoBehaviour
{
    protected Animator anim;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}
