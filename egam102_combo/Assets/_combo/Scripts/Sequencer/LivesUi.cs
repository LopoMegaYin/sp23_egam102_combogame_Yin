using TMPro;
using UnityEngine;

namespace MicroCombo
{
    public class LivesUi : MonoBehaviour
    {
        // UI information
        [SerializeField] private TextMeshProUGUI _liveText = null;

        private int _maxLives = 4;

        public void Init(int max)
        {
            _maxLives = max;
            SetLives(_maxLives);
        }

        public void SetLives(int count)
        {
            _liveText.text = string.Format("Lives: {0}", count);
        }
    }
}
