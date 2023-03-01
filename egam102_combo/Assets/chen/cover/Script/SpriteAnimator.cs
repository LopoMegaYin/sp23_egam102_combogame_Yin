using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    // Edit from Chad
    // Adding "new" here resolves the warning from Unity
    // This is because "renderer" is a special Unity name
    public new SpriteRenderer renderer;
    
    public List<Sprite> spriteList;
    int spriteIndex;

    public float spriteDuration = 0.1f;

    float timer;

    // Update is called once per frame
    void Start()
    {

    }
    
    void Update()
    {
        timer += Time.deltaTime;

        
        if (timer >= spriteDuration)
        {
            spriteIndex++;

            Sprite newSprite = spriteList[spriteIndex % spriteList.Count];
            renderer.sprite = newSprite;

            timer= 0;
        }

        
    }
}
