using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spriteChange : MonoBehaviour
{
    public GameObject Hand2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hand2.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
