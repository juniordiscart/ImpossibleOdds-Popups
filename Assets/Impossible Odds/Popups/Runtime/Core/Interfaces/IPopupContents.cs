using System;

namespace ImpossibleOdds.Popups
{
    public interface IPopupContents
    {
        /// <summary>
        /// Invoked when the popup should be closed. 
        /// </summary>
        event Action onClosePopup;
    }
}

