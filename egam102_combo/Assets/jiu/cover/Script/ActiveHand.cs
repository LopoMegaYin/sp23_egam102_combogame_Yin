using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveHand : MonoBehaviour
{
    public GameObject HgameObjectToDeactivate;

    private IEnumerator Countdown2()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f); //wait 2 seconds
            GetComponent<Renderer>().material.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 1f);                                    //do thing
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 0);
        StartCoroutine(Countdown2());
    }
}
