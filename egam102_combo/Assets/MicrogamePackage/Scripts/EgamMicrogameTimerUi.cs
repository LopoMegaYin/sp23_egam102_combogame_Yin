using UnityEngine;
using UnityEngine.UI;

public class EgamMicrogameTimerUi : MonoBehaviour
{   
    // UI
    [SerializeField] private Slider _timerUi = null;

    public void SetInterp(float interp)
    {
        _timerUi.SetValueWithoutNotify(interp);
    }
}
