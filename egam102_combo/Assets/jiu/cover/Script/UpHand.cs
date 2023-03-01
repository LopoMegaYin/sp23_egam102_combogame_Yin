using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpHand : MonoBehaviour
{
    public GameObject gameObjectToDeactivate;

    private IEnumerator Countdown2()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f); //wait 2 seconds
            gameObjectToDeactivate.SetActive(false);                                  //do thing
        }
    }

    void Start()
    {       
        StartCoroutine(Countdown2());
    }
}
