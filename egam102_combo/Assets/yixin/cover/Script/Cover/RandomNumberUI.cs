using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RandomNumberUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image imageComp;
    public Sprite[] numberSprite;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counter==0)
        {
            RandomNumber();
            ShowSprite();
            counter++;
        }
    }
    void RandomNumber()
    {
        StaticValue.randomNumber = Random.Range(0, numberSprite.Length);
    }

    void ShowSprite()
    {
        imageComp.sprite = numberSprite[StaticValue.randomNumber];
    }
}
