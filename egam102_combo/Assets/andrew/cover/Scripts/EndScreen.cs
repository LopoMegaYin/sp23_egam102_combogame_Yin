using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public SpriteRenderer EndIMG;
    public SpriteRenderer GOIMG;
    public byte EndBG;
    public byte GameOverBG;
    public GameObject Failstate;
    public GameObject FailstateMSC;
    public GameObject LvLMSC1;
    public GameObject LvLMSC2;
    public GameObject LvLMSC3;

    void Awake()
    {
        EndBG += 1;
        LvLMSC1.SetActive(false);
        LvLMSC2.SetActive(false);
        LvLMSC3.SetActive(false);
        FailstateMSC.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       if (EndBG < 160)
        {
            EndBG += 1;
            EndIMG.color = new Color32(48, 48, 48, EndBG);
        }

        if ((EndBG == 160) && (GameOverBG < 255))
        {
            GameOverBG += 1;
            GOIMG.color = new Color32(255, 255, 255, GameOverBG);   
        }

        if (GameOverBG > 254)
        {
            Failstate.SetActive(true);    
        }
    }
}