using System.Collections.Generic;

namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// Configuration data for a simple notification popup.
    /// A notification popup only shows textual information which can be clicked away.
    /// </summary>
    public struct NotificationPopupDescription : ISimplePopupDescription
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
        string ISimplePopupDescription.Header => header;

        /// <inheritdoc />
        string ISimplePopupDescription.Contents => contents;

        /// <inheritdoc />
        IEnumerable<PopupButtonDescription> ISimplePopupDescription.Buttons => new[] { hideButtonDescription };
    }
}

