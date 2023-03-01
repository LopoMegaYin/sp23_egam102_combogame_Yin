using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectCollide : MonoBehaviour
{
    public EgamMicrogameInstance microgameInstance;
    public EgamMicrogameHelper egamMicrogameHelper;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Stick")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;

            // Edit from Chad
            // The "Microgame Reference" doc on Canvas explains the right way to do this
            // Remember you CANNOT edit the files inside of the MicrogamePackage folder
            
            EgamMicrogameInstance instance = GameObject.FindObjectOfType<EgamMicrogameInstance>();
            instance.WinGame();

            // egamMicrogameHelper.instance._timeoutType = EgamMicrogameHelper.WinLose.Win;
            // egamMicrogameHelper.instance._duration = 0;

        }
    }
    public void OnWinCondition()
    {
        microgameInstance.WinGame();
    }
}
