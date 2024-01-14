using System.Collections.Generic;

namespace ImpossibleOdds.Popups
{
    public struct ComplexPopupDescription : IPopupDescription
    {
        public string header;
        public string contents;
        public PopupButtonDescription[] popupButtons;

        /// <inheritdoc />
        string IPopupDescription.Header => header;

        /// <inheritdoc />
        string IPopupDescription.Contents => contents;

        /// <inheritdoc />
        IEnumerable<PopupButtonDescription> IPopupDescription.Buttons => popupButtons;
    }
}

