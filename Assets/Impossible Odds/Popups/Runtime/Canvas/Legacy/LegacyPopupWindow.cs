using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ImpossibleOdds.Popups.Canvas.Legacy
{
    public class LegacyPopupWindow : CanvasDefaultPopupWindow
    {
        [SerializeField]
        private Text header;
        [SerializeField]
        private Text contents;

        [SerializeField]
        private RectTransform buttonRoot;

        [SerializeField]
        private LegacyPopupButton buttonPrefab;
        
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
                LegacyPopupButton button = Instantiate(buttonPrefab, buttonRoot);
                button.ButtonInfo = popupButton;
                button.onButtonClicked += CallOnHidePopup;
            }
        }
    }
}

