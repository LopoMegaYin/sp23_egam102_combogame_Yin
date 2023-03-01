using UnityEngine;

public class EgamMicrogameResultsUi : MonoBehaviour
{   
    // Handles
    [SerializeField] private GameObject _winEnableHandle = null;
    [SerializeField] private GameObject _loseEnableHandle = null;

    public void Reset()
    {
        // Turn everything off
        _winEnableHandle.SetActive(false);
        _loseEnableHandle.SetActive(false);
    }

    public void SetResult(EgamMicrogameHelper.WinLose type)
    {
        switch (type)
        {
            case EgamMicrogameHelper.WinLose.Win:
                _winEnableHandle.SetActive(true);
                break;

            case EgamMicrogameHelper.WinLose.Lose:
                _loseEnableHandle.SetActive(true);
                break;
        }
    }
}
