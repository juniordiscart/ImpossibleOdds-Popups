using System.Collections.Generic;

namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// Configuration data for a simple confirmation popup.
    /// A confirmation popup only shows textual information that displays a choice the player can make.
    /// </summary>
    public struct ConfirmationPopupDescription : ISimplePopupDescription
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
        public PopupButtonDescription confirmButtonDescription;

        /// <summary>
        /// The confirmation's cancel button.
        /// </summary>
        public PopupButtonDescription cancelButtonDescription;

        /// <inheritdoc />
        string ISimplePopupDescription.Header => header;

        /// <inheritdoc />
        string ISimplePopupDescription.Contents => contents;

        /// <inheritdoc />
        IEnumerable<PopupButtonDescription> ISimplePopupDescription.Buttons => new[] { confirmButtonDescription, cancelButtonDescription };
    }
}
