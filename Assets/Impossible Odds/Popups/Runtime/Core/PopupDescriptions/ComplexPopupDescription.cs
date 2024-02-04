using System.Collections.Generic;

namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// Configuration data for a default popup with multiple options.
    /// A complex popup only shows textual information which offers multiple options for the player to pick from.
    /// </summary>
    public struct ComplexPopupDescription : IDefaultPopupDescription
    {
        /// <summary>
        /// The popup's header text to be displayed.
        /// </summary>
        public string header;
        
        /// <summary>
        /// The popup's informational text.
        /// </summary>
        public string contents;
        
        /// <summary>
        /// The popup's buttons representing the different options the player can make.
        /// </summary>
        public PopupButtonDescription[] popupButtons;

        /// <inheritdoc />
        string IDefaultPopupDescription.Header => header;

        /// <inheritdoc />
        string IDefaultPopupDescription.Contents => contents;

        /// <inheritdoc />
        IEnumerable<PopupButtonDescription> IDefaultPopupDescription.Buttons => popupButtons;
    }
}

