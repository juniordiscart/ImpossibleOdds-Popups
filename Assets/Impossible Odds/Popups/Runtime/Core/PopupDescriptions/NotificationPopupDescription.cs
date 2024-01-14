using System.Collections.Generic;

namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// Configuration data for a simple notification popup.
    /// A notification popup only shows textual information which can be clicked away.
    /// </summary>
    public struct NotificationPopupDescription : IPopupDescription
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
        public PopupButtonDescription hideButtonDescription;

        /// <inheritdoc />
        string IPopupDescription.Header => header;

        /// <inheritdoc />
        string IPopupDescription.Contents => contents;

        /// <inheritdoc />
        IEnumerable<PopupButtonDescription> IPopupDescription.Buttons => new[] { hideButtonDescription };
    }
}

