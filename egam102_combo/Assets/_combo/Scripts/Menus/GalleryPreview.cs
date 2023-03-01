using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MicroCombo
{
    public class GalleryPreview : MonoBehaviour
    {
        // UI information
        [SerializeField] private Image _iconImage = null;
        [SerializeField] private Sprite _backupSprite = null;

        [SerializeField] private TextMeshProUGUI _nameText = null;
        [SerializeField] private TextMeshProUGUI _studentText = null;
        [SerializeField] private TextMeshProUGUI _countText = null;
        [SerializeField] private TextMeshProUGUI _descriptionText = null;

        public void SetData(MicrogameData data)
        {
            Sprite iconSprite = data.GetGallerySprite();
            if (iconSprite == null)
            {
                iconSprite = _backupSprite;
            }
            _iconImage.sprite = iconSprite;

            _nameText.text = data.microgameName;
            _studentText.text = data.studentName;
            _countText.text = string.Format("Game #{0}", data.microgameNumber);
            _descriptionText.text = data.galleryString;    
        }
    }
}
