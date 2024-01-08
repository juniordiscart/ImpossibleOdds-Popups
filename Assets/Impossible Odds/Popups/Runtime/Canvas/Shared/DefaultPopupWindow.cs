using System.Collections.Generic;

namespace ImpossibleOdds.Popups.Canvas
{
    public abstract class DefaultPopupWindow : PopupWindow
    {
        /// <summary>
        /// The text contents of the popup window.
        /// </summary>
        public abstract string Contents
        {
            get;
            set;
        }

        /// <summary>
        /// The popup buttons.
        /// </summary>
        /// <param name="buttons">The buttons to be displayed on the popup.</param>
        public abstract void SetButtons(IEnumerable<PopupButton> buttons);
    }
}

