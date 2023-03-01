using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DownHandcloseH : MonoBehaviour
{
    public GameObject DgameObjectToDeactivate;
    public EgamMicrogameInstance microgameInstance;

    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 0);
        EgamMicrogameInstance microgameInstance = GameObject.FindObjectOfType<EgamMicrogameInstance>();
    }   

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Renderer>().material.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 1f);
            DgameObjectToDeactivate.SetActive(true);
            //Debug.Log("d");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (collision.isTrigger != true && collision.CompareTag("stick"))
            {
                Debug.Log("hi");
                microgameInstance.WinGame();               
            }
        }            
    }
}
