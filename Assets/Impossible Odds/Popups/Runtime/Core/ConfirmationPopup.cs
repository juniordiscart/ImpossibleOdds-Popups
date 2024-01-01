using System.Collections.Generic;

namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// Configuration data for a simple confirmation popup.
    /// A confirmation popup only shows textual information that displays a choice the player can make.
    /// </summary>
    public struct ConfirmationPopup : IPopupDescription
    {
        /// <summary>
        /// The confirmation's header text.
        /// </summary>
        public string header;
        
        /// <summary>
        /// The confirmation's informational text.
        /// </summary>
        public string contents;

        /// <summary>
        /// The confirmation's confirm button.
        /// </summary>
        public PopupButton confirmButton;

        /// <summary>
        /// The confirmation's cancel button.
        /// </summary>
        public PopupButton cancelButton;

        /// <inheritdoc />
        string IPopupDescription.Header => header;

        /// <inheritdoc />
        string IPopupDescription.Contents => contents;

        /// <inheritdoc />
        IEnumerable<PopupButton> IPopupDescription.Buttons => new[] { confirmButton, cancelButton };
    }
}
