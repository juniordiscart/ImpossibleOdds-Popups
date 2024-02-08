using System.Collections.Generic;

namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// Description to display a simple textual popup with zero or more buttons.
    /// </summary>
    public struct SimplePopupDescription
    {
        /// <summary>
        /// The header text of the popup.
        /// </summary>
        public string Header
        {
            get;
            set;
        }

        /// <summary>
        /// The text contents of the popup.
        /// </summary>
        public string Contents
        {
            get;
            set;
        }

        /// <summary>
        /// The buttons on the popup.
        /// </summary>
        public IEnumerable<PopupButtonDescription> Buttons
        {
            get;
            set;
        }
    }
}

