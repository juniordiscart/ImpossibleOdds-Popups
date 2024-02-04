using System;
using System.Collections;

namespace ImpossibleOdds.Popups
{
    public interface IPopupHandle : IEnumerator
    {
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
    }
}

