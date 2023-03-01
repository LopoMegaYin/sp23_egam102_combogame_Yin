using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MicroCombo
{
    public class MenuTab : MonoBehaviour
    {
        // Shared info
        private MenuManager _menu;

        [SerializeField] private MenuBase.TabType _type = MenuBase.TabType.Play;
        [SerializeField] private GameObject _enableHandle = null;

        // UI information
        [SerializeField] private Image _iconImage = null;
        [SerializeField] private TextMeshProUGUI _nameText = null;

        [SerializeField] private Button _button = null;
        public Button button
        {
            get { return _button; }
        }

        void Awake()
        {
            _button.onClick.AddListener(OnClicked);
        }

        public void Init(MenuManager menu, MenuData menuData)
        {
            _menu = menu;
            _type = menuData.tabType;

            // Switch based on type?
            _iconImage.sprite = menuData.icon;
            _nameText.text = menuData.text;
        }

        public void SetVisible(bool isVisible)
        {
            _enableHandle.SetActive(isVisible);
        }

        private void OnClicked()
        {
            _menu.SetTab(_type);
        }
    }
}