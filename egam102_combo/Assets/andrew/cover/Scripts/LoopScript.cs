using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScript : MonoBehaviour
{
    public float Spawn;
   
    public GameObject[] asteroidGOs;
    public Sprite[] asteroidSprites;
    public GameObject RedDewbot;

    public float randomspwn;
    public int randomx;
    public int randomy;
    float next_spawn_time;

    private void Awake()
    {
        randomx = UnityEngine.Random.Range(6, -6);
        randomy = UnityEngine.Random.Range(5, 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        next_spawn_time = Time.time + 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next_spawn_time)
        {
            randomspwn = UnityEngine.Random.Range(1, 4);
            
            if (randomspwn == 1)
            {
            Instantiate(RedDewbot, new Vector3(5, -1, 0), Quaternion.identity);
            }

            if (randomspwn == 2)
            {
                Instantiate(RedDewbot, new Vector3(-5, -1, 0), Quaternion.identity);
            }

            if (randomspwn == 3)
            {
                Instantiate(RedDewbot, new Vector3(1, 3, 0), Quaternion.identity);
            }

            if (randomspwn == 4)
            {
                Instantiate(RedDewbot, new Vector3(0, 3, 0), Quaternion.identity);
            }

            //increment next_spawn_time
            next_spawn_time += 10.0f;
        }
    }
}
