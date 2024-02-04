using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ImpossibleOdds.Popups.Canvas.Legacy
{
    /// <summary>
    /// Default popup contents for displaying a simple text message with buttons.
    /// </summary>
    [AddComponentMenu("Impossible Odds/Popups/Canvas/Legacy/Popup Default Contents")]
    public class PopupDefaultContents : ImpossibleOdds.Popups.Canvas.PopupDefaultContents
    {
        [SerializeField]
        private Text contents;
        
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

