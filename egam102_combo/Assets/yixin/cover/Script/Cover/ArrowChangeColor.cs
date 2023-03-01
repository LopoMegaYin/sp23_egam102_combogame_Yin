using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowChangeColor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float timer;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == 0)
        {
            timer += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(spriteRenderer.color,Color.green, speed*Time.deltaTime);
        }
        else if (timer < 0.1 )
        {
            timer += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.blue, speed * Time.deltaTime);
        }
        else if(timer<0.2)
        {
            timer += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.red, speed * Time.deltaTime);
            
        }
        else if (timer < 0.3)
        {
            timer += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.yellow, speed * Time.deltaTime);

        }
        else if(timer>0.3)
        {
            timer = 0;
        }

    }
}
