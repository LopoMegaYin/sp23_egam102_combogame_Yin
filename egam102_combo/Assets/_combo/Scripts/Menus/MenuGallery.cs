using System.Collections.Generic;
using UnityEngine;

namespace MicroCombo
{
    public class MenuGallery : MenuBase
    {
        // UI informatino
        [SerializeField] private GalleryButton _buttonPrefab = null;
        [SerializeField] private Transform _buttonParentHandle = null;

        private List<GalleryButton> _buttons = new List<GalleryButton>();

        [SerializeField] private GalleryPreview _preview = null;

        public override void Init(MenuManager menuManager, MenuData menuData)
        {
            // Build the UIs
            MicrogameDictionary dictionary = menuManager.comboManager.dictionary;
            
            List<MicrogameData> datas = new List<MicrogameData>();
            dictionary.GetDatas(ref datas, string.Empty, false, -1);

            // Create / set
            for (int i = 0; i < datas.Count; i++)
            {
                GalleryButton button = GetButton(i);
                button.SetData(datas[i]);

                _buttons[i].gameObject.SetActive(true);
            }
            
            // Deactivate leftovers
            for (int i = datas.Count; i < _buttons.Count; i++)
            {
                _buttons[i].gameObject.SetActive(false);
            }

            // Set the gallery to the first one?
            if (datas.Count > 0)
            {
                OnButtonPressed(datas[0]);
            }            
        }

        private GalleryButton GetButton(int index)
        {
            while (index >= _buttons.Count)
            {
                GalleryButton newButton = GameObject.Instantiate<GalleryButton>(_buttonPrefab);
                newButton.transform.SetParent(_buttonParentHandle, false);
                newButton.Init(this);        

                _buttons.Add(newButton);        
            }

            return _buttons[index];
        }

        public void OnButtonPressed(MicrogameData data)
        {
            // Populate the viewer
            _preview.SetData(data);
        }
    }
}