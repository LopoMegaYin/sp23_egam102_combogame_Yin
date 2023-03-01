using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrobot_Anim : MonoBehaviour
{
    public Sprite StopIMG;
    public Sprite GoIMG;
    public Sprite KindaGo;
    public EXP_ShipMovement player;
    public Rigidbody2D playerRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<EXP_ShipMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && (player.currentwater > 0))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = GoIMG;
        }

        if (Input.GetKey(KeyCode.Space) && (player.currentwater == 0))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = KindaGo;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = StopIMG;
        }

    }
}
