using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ImpossibleOdds.Popups.Canvas.TextMeshPro
{
    public class TMPPopupWindow : DefaultPopupWindow
    {
        [SerializeField]
        private TMP_Text header;
        [SerializeField]
        private TMP_Text contents;

        [SerializeField]
        private RectTransform buttonRoot;

        [SerializeField]
        private TMPPopupButton buttonPrefab;

        /// <inheritdoc />
        public override string Header
        {
            get => header.text;
            set => header.text = value;
        }

        /// <summary>
        /// The text contents of the popup window.
        /// </summary>
        public override string Contents
        {
            get => contents.text;
            set => contents.text = value;
        }

        /// <inheritdoc />
        public override bool DestroyPopupWindowOnHide => true;

        /// <inheritdoc />
        public override void SetButtons(IEnumerable<PopupButton> buttons)
        {
            foreach (PopupButton popupButton in buttons)
            {
                TMPPopupButton button = Instantiate(buttonPrefab, buttonRoot);
                button.ButtonInfo = popupButton;
                button.onButtonClicked += CallOnHidePopup;
            }
        }
    }
}
