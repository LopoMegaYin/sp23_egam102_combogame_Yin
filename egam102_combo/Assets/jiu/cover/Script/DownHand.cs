using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownHand : MonoBehaviour
{
    public GameObject gameObjectToDeactivate;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gameObjectToDeactivate.SetActive(false);
        }
    }
}
