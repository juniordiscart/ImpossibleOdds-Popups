using System.Collections.Generic;

namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// Configuration data for a simple notification popup.
    /// A notification popup only shows textual information which can be clicked away.
    /// </summary>
    public struct NotificationPopupDescription : IDefaultPopupDescription
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
        string IDefaultPopupDescription.Header => header;

        /// <inheritdoc />
        string IDefaultPopupDescription.Contents => contents;

        /// <inheritdoc />
        IEnumerable<PopupButtonDescription> IDefaultPopupDescription.Buttons => new[] { hideButtonDescription };
    }
}

