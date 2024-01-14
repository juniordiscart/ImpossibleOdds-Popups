using System.Collections.Generic;

namespace ImpossibleOdds.Popups
{
    public interface IPopupDescription
    {
        /// <summary>
        /// The header text of the popup.
        /// </summary>
        string Header
        {
            get;
        }

        /// <summary>
        /// The text contents of the popup.
        /// </summary>
        string Contents
        {
            get;
        }

        /// <summary>
        /// The buttons on the popup.
        /// </summary>
        IEnumerable<PopupButtonDescription> Buttons
        {
            get;
        }
    }
}

