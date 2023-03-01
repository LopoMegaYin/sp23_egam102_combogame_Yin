using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameInstanceGetter : MonoBehaviour
{
    public EgamMicrogameInstance microgameInstance;

    public void OnWinCondition()
    {
        microgameInstance.WinGame();
    }

}
