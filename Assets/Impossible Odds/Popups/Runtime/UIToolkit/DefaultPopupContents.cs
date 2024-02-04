using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace ImpossibleOdds.Popups.UIToolkit
{
    /// <summary>
    /// The popup contents that ties together the contents for a default popup.
    /// </summary>
    public class DefaultPopupContents : IPopupContents
    {
        /// <inheritdoc />
        public event Action onClosePopup;
        
        private readonly TextElement contentsElement;
        private readonly VisualElement buttonRootElement;
        private readonly VisualTreeAsset buttonTreeAsset;

        public DefaultPopupContents(TextElement contentsElement, VisualElement buttonRootElement, VisualTreeAsset buttonTreeAsset)
        {
            contentsElement.ThrowIfNull(nameof(contentsElement));
            buttonRootElement.ThrowIfNull(nameof(buttonRootElement));
            buttonTreeAsset.ThrowIfNull(nameof(buttonTreeAsset));

            this.contentsElement = contentsElement;
            this.buttonRootElement = buttonRootElement;
            this.buttonTreeAsset = buttonTreeAsset;
        }

        /// <summary>
        /// Sets the textual information for this popup.
        /// </summary>
        /// <param name="contents">The textual information to display.</param>
        public void SetContents(string contents)
        {
            contentsElement.text = contents;
        }

        /// <summary>
        /// Spawns the buttons for this popup.
        /// </summary>
        /// <param name="buttons">The button descriptions to display on the popup.</param>
        public void SetButtons(IEnumerable<PopupButtonDescription> buttons)
        {
            buttons.ThrowIfNull(nameof(buttons));
            
            foreach (PopupButtonDescription popupButton in buttons)
            {
                buttonTreeAsset.CloneTree(buttonRootElement, out int firstElementIndex, out int elementAddedCount);

                if (elementAddedCount != 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(elementAddedCount), $"The {nameof(DefaultPopupContents)} expects only a single root element when creating a popup button.");
                }
                
                Button button = buttonRootElement[firstElementIndex].Q<Button>();
                button.text = popupButton.text;

                if (popupButton.icon != null)
                {
                    button.Add(new Image()
                    {
                        image = popupButton.icon.texture
                    });
                }
                
                button.clicked += popupButton.onClickAction;
                button.clicked += OnClosePopup;
            }
        }

        private void OnClosePopup()
        {
            onClosePopup.InvokeIfNotNull();
        }
    }
}

