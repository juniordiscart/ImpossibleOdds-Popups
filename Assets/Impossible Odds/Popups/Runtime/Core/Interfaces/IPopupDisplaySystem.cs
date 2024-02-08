namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// Popup display system interface.
    /// A concrete implementation defines how popups are displayed, e.g. Canvas or UI Toolkit.
    /// </summary>
    public interface IPopupDisplaySystem
    {
        /// <summary>
        /// Checks whether any popup is currently being displayed by this popup system.
        /// </summary>
        /// <returns>True if a popup is currently being displayed. False otherwise.</returns>
        bool IsShowingPopups();
        
        /// <summary>
        /// Checks whether the provided popup handle is being displayed by this popup system.
        /// </summary>
        /// <param name="popupHandle">The popup handle to check with the popup system.</param>
        /// <returns>True if it is being displayed. False otherwise.</returns>
        bool IsShowingPopup(IPopupHandle popupHandle);

        /// <summary>
        /// Shows a simple textual popup with zero, one or more options.
        /// Note: if no options are given to the user to interact with the popup, it's the caller's responsibility to dismiss the popup.
        /// </summary>
        /// <param name="popupDescription">The description of the popup to display.</param>
        /// <returns>A handle to the popup window.</returns>
        IPopupHandle ShowSimplePopup(SimplePopupDescription popupDescription);

        /// <summary>
        /// Shows a custom popup window in the display system.
        /// </summary>
        /// <param name="customData">The popup data to show in this display system.</param>
        /// <returns>A handle to the custom popup window.</returns>
        IPopupHandle ShowCustomPopup(ICustomPopupDescription customData);

        /// <summary>
        /// Close the popup window if it was active by this display system.
        /// </summary>
        /// <param name="popupHandle">The popup window to close.</param>
        void ClosePopup(IPopupHandle popupHandle);
    }
}

