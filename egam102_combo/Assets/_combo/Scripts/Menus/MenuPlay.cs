using UnityEngine;
using UnityEngine.UI;

namespace MicroCombo
{
    public class MenuPlay : MenuBase
    {
        // UI info
        [SerializeField] private Button _playButton = null;

        void Awake()
        {
            _playButton.onClick.AddListener(OnPlay);
        }

        public void OnPlay()
        {
            // Launch the game!
            ComboManager comboManager = GameObject.FindObjectOfType<ComboManager>();
            comboManager.GoToGame();
        }
    }
}