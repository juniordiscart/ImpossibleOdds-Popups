namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// Popup display system interface.
    /// A concrete implementation defines how popups are displayed, e.g. Canvas or UI Toolkit.
    /// </summary>
    public interface IPopupDisplaySystem
    {
        /// <summary>
        /// Shows a notification popup.
        /// </summary>
        /// <param name="notificationData">The data to build the notification popup.</param>
        /// <returns>A handle to the popup window.</returns>
        IPopupWindow ShowNotification(NotificationPopup notificationData);

        /// <summary>
        /// Shows a confirmation popup.
        /// </summary>
        /// <param name="confirmationData">The data to build the confirmation popup.</param>
        /// <returns>A handle to the popup window.</returns>
        IPopupWindow ShowConfirmation(ConfirmationPopup confirmationData);

        /// <summary>
        /// Shows a complex popup with multiple options.
        /// </summary>
        /// <param name="complexData">The data to build the complex popup.</param>
        /// <returns>A handle to the popup window.</returns>
        IPopupWindow ShowComplexPopup(ComplexPopup complexData);

        /// <summary>
        /// Shows a custom popup window in the display system.
        /// </summary>
        /// <param name="popupWindow">The popup window to show in this popup display system.</param>
        /// <returns>A handle to the popup window.</returns>
        IPopupWindow ShowCustomPopup(IPopupWindow popupWindow);

        /// <summary>
        /// Close the popup window if it was active by this display system.
        /// </summary>
        /// <param name="popupWindow">The popup window to close.</param>
        void ClosePopup(IPopupWindow popupWindow);
    }
}

