using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameInstancegetter : MonoBehaviour
{
    public EgamMicrogameInstance microgameInstance;

    public void MyFunction()
    {
        EgamMicrogameInstance microgameInstance = GameObject.FindObjectOfType<EgamMicrogameInstance>();
    }

}
