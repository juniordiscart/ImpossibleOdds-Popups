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
        /// Shows a notification popup.
        /// </summary>
        /// <param name="notificationData">The data to build the notification popup.</param>
        /// <returns>A handle to the popup window.</returns>
        IPopupHandle ShowNotification(NotificationPopupDescription notificationData);

        /// <summary>
        /// Shows a confirmation popup.
        /// </summary>
        /// <param name="confirmationData">The data to build the confirmation popup.</param>
        /// <returns>A handle to the popup window.</returns>
        IPopupHandle ShowConfirmation(ConfirmationPopupDescription confirmationData);

        /// <summary>
        /// Shows a complex popup with multiple options.
        /// </summary>
        /// <param name="complexData">The data to build the complex popup.</param>
        /// <returns>A handle to the popup window.</returns>
        IPopupHandle ShowComplexPopup(ComplexPopupDescription complexData);

        /// <summary>
        /// Shows a custom popup window in the display system.
        /// </summary>
        /// <param name="customData">The popup data to show in this popup display system.</param>
        /// <returns>A handle to the custom popup window.</returns>
        IPopupHandle ShowCustomPopup(ICustomPopupDescription customData);

        /// <summary>
        /// Close the popup window if it was active by this display system.
        /// </summary>
        /// <param name="popupHandle">The popup window to close.</param>
        void ClosePopup(IPopupHandle popupHandle);
    }
}

