using System.Collections.Generic;

namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// Configuration data for a simple notification popup.
    /// A notification popup only shows textual information which can be clicked away.
    /// </summary>
    public struct NotificationPopup : IPopupDescription
    {
        /// <summary>
        /// The notification's header text.
        /// </summary>
        public string header;
        
        /// <summary>
        /// The notification's informational text.
        /// </summary>
        public string contents;
        
        /// <summary>
        /// The notification's button information.
        /// </summary>
        public PopupButton hideButton;

        /// <inheritdoc />
        string IPopupDescription.Header => header;

        /// <inheritdoc />
        string IPopupDescription.Contents => contents;

        /// <inheritdoc />
        IEnumerable<PopupButton> IPopupDescription.Buttons => new[] { hideButton };
    }
}

