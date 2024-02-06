using System;
using System.Collections;

namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// A handle interface for dealing with a specific popup being shown or displayed by a popup display system.
    /// </summary>
    public interface IPopupHandle : IEnumerator
    {
        /// <summary>
        /// Invoked when the popup should be closed.
        /// </summary>
        event Action<IPopupHandle> onClosePopup;
        
        /// <summary>
        /// A reference to the popup window.
        /// </summary>
        IPopupContents PopupContents
        {
            get;
        }
        
        /// <summary>
        /// The popup display system this popup is being shown on.
        /// </summary>
        IPopupDisplaySystem DisplaySystem
        {
            get;
        }

        /// <summary>
        /// Is the popup still being shown by the popup display system?
        /// </summary>
        bool IsShowing => DisplaySystem.IsShowingPopup(this);

        /// <summary>
        /// Attempts to close the popup window with the display system.
        /// </summary>
        void ClosePopup();
    }
}

