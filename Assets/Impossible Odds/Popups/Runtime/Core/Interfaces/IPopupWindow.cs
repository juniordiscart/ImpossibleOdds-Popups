using System;

namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// Popup window interface.
    /// </summary>
    public interface IPopupWindow
    {
        /// <summary>
        /// Called when the popup should be hidden.
        /// </summary>
        event Action onHidePopup;
    }
}

