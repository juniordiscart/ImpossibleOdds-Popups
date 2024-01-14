using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ImpossibleOdds.Popups.Canvas.TextMeshPro
{
    [AddComponentMenu("Impossible Odds/Popups/Canvas/Text Mesh Pro/Default Popup Window")]
    public class PopupWindow : DefaultPopupWindow
    {
        [SerializeField]
        private TMP_Text header;
        [SerializeField]
        private TMP_Text contents;

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
