using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pow : MonoBehaviour
{
    public Transform player;
    public float y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.position.x, y, 0);
    }
}
