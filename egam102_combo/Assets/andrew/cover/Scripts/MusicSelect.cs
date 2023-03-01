using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelect : MonoBehaviour
{
    public GameObject LvlMSC3;
    public GameObject LvlMSC2;
    public GameObject LvLMSC1;
    public float randomspwn;

    void Awake()
    {
        randomspwn = UnityEngine.Random.Range(1, 4);
        if (randomspwn == 1)
        {
            LvLMSC1.SetActive(true);
        }

        if (randomspwn == 2)
        {
            LvlMSC2.SetActive(true);
        }

        if (randomspwn == 3)
        {
            LvlMSC3.SetActive(true);
        }

        if (randomspwn == 2)
        {
            LvlMSC2.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
