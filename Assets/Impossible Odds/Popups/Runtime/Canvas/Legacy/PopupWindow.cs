using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ImpossibleOdds.Popups.Canvas.Legacy
{
    [AddComponentMenu("Impossible Odds/Popups/Canvas/Legacy/Default Popup Window")]
    public class PopupWindow : DefaultPopupWindow
    {
        [SerializeField]
        private Text header;
        [SerializeField]
        private Text contents;

        [SerializeField]
        private RectTransform buttonRoot;

        [SerializeField]
        private PopupButton buttonPrefab;
        
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
        public override void SetButtons(IEnumerable<PopupButtonDescription> buttons)
        {
            foreach (PopupButtonDescription popupButton in buttons)
            {
                PopupButton button = Instantiate(buttonPrefab, buttonRoot);
                button.ButtonDescriptionInfo = popupButton;
                button.onButtonClicked += CallOnHidePopup;
            }
        }
    }
}

