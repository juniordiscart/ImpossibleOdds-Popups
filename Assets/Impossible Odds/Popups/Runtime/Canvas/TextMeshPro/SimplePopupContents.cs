using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ImpossibleOdds.Popups.Canvas.TextMeshPro
{
    /// <summary>
    /// Default popup contents for displaying a simple text message with buttons.
    /// </summary>
    [AddComponentMenu("Impossible Odds/Popups/Canvas/Text Mesh Pro/Simple Popup Contents")]
    public class SimplePopupContents : ImpossibleOdds.Popups.Canvas.SimplePopupContents
    {
        [SerializeField]
        private TMP_Text contents;

        [SerializeField]
        private RectTransform buttonRoot;

        [SerializeField]
        private PopupButton buttonPrefab;

        /// <inheritdoc />
        public override void SetContents(string contents)
        {
            this.contents.text = contents;
        }

        /// <inheritdoc />
        public override void SetButtons(IEnumerable<PopupButtonDescription> buttons)
        {
            foreach (PopupButtonDescription popupButton in buttons)
            {
                PopupButton button = Instantiate(buttonPrefab, buttonRoot);
                button.ButtonDescriptionInfo = popupButton;
                button.onButtonClicked += OnClosePopup;
            }
        }
    }
}

