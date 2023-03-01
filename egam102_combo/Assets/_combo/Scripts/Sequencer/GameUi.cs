using UnityEngine;
using UnityEngine.UI;

namespace MicroCombo
{
    public class GameUi : MonoBehaviour
    {
        // UI 
        [SerializeField] private Sprite _backupSprite = null;
        [SerializeField] private Image _iconImage = null;

        [SerializeField] private GameObject _winEnableHandle = null;
        [SerializeField] private GameObject _loseEnableHandle = null;

        // Animation
        [SerializeField] private SpringInterper _interper = null;

        public void SetData(MicrogameData data)
        {
            Sprite icon = data.GetGallerySprite();
            if (icon == null)
            {
                icon = _backupSprite;
            }
            _iconImage.sprite = icon;

            _winEnableHandle.SetActive(false);
            _loseEnableHandle.SetActive(false);
        }

        public void SetInterp(float interp, bool instant)
        {
            _interper.SetGoal(interp, instant);
        }

        public void SetResult(bool isWin)
        {
            _winEnableHandle.SetActive(isWin);
            _loseEnableHandle.SetActive(!isWin);
        }
    }
}
