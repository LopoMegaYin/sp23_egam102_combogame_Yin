using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerLife : MonoBehaviour
{
    public float currentlife;
    public float maxlife;
    public float lifeloss;
    public float wateradd;

    public Image LifeUI;
    public SpriteRenderer PlantIMG;
    public GameObject playerkill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LifeUI.fillAmount = (currentlife / maxlife);

        if (currentlife > 0)
        {
            currentlife = currentlife - lifeloss;
        }

        if (currentlife < 0)
        {
            currentlife = 0;
        }

        //Visual Feedback as Plant Life depleats
        if (currentlife > 67)
        {
            PlantIMG.color = new Color32(35, 255, 42, 255);
            LifeUI.color = new Color32(35, 255, 42, 255);
        }

        if (currentlife > 34 && currentlife < 67)
        {
            PlantIMG.color = new Color32(255, 234, 35, 255);
            LifeUI.color = new Color32(255, 234, 35, 255);
        }

        if (currentlife > 0.0001 && currentlife < 34)
        {
            PlantIMG.color = new Color32(255, 88, 35, 255);
            LifeUI.color = new Color32(255, 88, 35, 255);
        }

        if (currentlife == 0)
        {
            PlantIMG.color = new Color32(152, 145, 118, 255);
            Destroy(GameObject.Find("Player"));
            playerkill.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "Bullet" && currentlife < 100 && currentlife > 0)
        {
            Debug.Log("Yep this works");
            currentlife = currentlife + wateradd;
        }
    }
}
