using System;

namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// The base interface for all popup contents.
    /// </summary>
    public interface IPopupContents
    {
        /// <summary>
        /// Invoked when the popup should be closed. 
        /// </summary>
        event Action onClosePopup;
    }
}

