using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MicroCombo
{
    public class GalleryButton : MonoBehaviour
    {
        // UI info
        [SerializeField] private Image _iconImage = null;
        [SerializeField] private TextMeshProUGUI _nameText = null;

        [SerializeField] private Sprite _backupSprite = null;

        [SerializeField] private Button _button = null;

        private MenuGallery _gallery = null;
        private MicrogameData _data = null;

        void Awake()
        {
            _button.onClick.AddListener(OnClicked);
        }

        public void Init(MenuGallery gallery)
        {
            _gallery = gallery;
        }

        public void SetData(MicrogameData data)
        {
            _data = data;

            Sprite iconSprite = data.GetGallerySprite();
            if (iconSprite == null)
            {
                iconSprite = _backupSprite;
            }
            _iconImage.sprite = iconSprite;

            _nameText.text = string.Format("{0}{1}", data.GetShortName(), data.microgameNumber);
        }

        private void OnClicked()
        {
            _gallery.OnButtonPressed(_data);
        }
    }
}