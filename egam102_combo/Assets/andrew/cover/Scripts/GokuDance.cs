using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuDance : MonoBehaviour
{

    public Animator gokuAnimator;
   
    // Update is called once per frame
    void Update()
    {
    //When G key is pressed animate
    if (Input.GetKeyDown (KeyCode.G))
        {
            gokuAnimator.SetTrigger("dance");
        }
    }
}
