using UnityEngine;

namespace ImpossibleOdds.Popups
{
    [RequireComponent(typeof(IPopupDisplaySystem)), AddComponentMenu("Impossible Odds/Popups/Popup System")]
    public class Popup : MonoBehaviour
    {
        private static Popup root;

        /// <summary>
        /// Checks whether any popup is currently being displayed by this popup system.
        /// </summary>
        /// <returns>True if a popup is currently being displayed. False otherwise.</returns>
        public static bool IsShowingPopups()
        {
            return root.displaySystem.IsShowingPopups();
        }

        /// <summary>
        /// Checks whether the provided popup handle is being displayed by this popup system.
        /// </summary>
        /// <param name="popupHandle">The popup handle to check with the popup system.</param>
        /// <returns>True if it is being displayed. False otherwise.</returns>
        public static bool IsShowingPopup(IPopupHandle popupHandle)
        {
            return root.displaySystem.IsShowingPopup(popupHandle);
        }

        /// <summary>
        /// Shows a notification popup.
        /// </summary>
        /// <param name="popupData">The data to build the notification popup.</param>
        /// <returns>A handle to the popup window.</returns>
        public static IPopupHandle ShowNotification(NotificationPopupDescription popupData)
        {
            return root.displaySystem.ShowNotification(popupData);
        }

        /// <summary>
        /// Shows a confirmation popup.
        /// </summary>
        /// <param name="popupData">The data to build the confirmation popup.</param>
        /// <returns>A handle to the popup window.</returns>
        public static IPopupHandle ShowConfirmation(ConfirmationPopupDescription popupData)
        {
            return root.displaySystem.ShowConfirmation(popupData);
        }

        /// <summary>
        /// Shows a complex popup with multiple options.
        /// </summary>
        /// <param name="popupData">The data to build the complex popup.</param>
        /// <returns>A handle to the popup window.</returns>
        public static IPopupHandle ShowComplex(ComplexPopupDescription popupData)
        {
            return root.displaySystem.ShowComplexPopup(popupData);
        }

        /// <summary>
        /// Shows a custom popup window in the display system.
        /// </summary>
        /// <param name="popupData">The popup data to show in this popup display system.</param>
        /// <returns>A handle to the popup window.</returns>
        public static IPopupHandle ShowCustom(ICustomPopupDescription popupData)
        {
            return root.displaySystem.ShowCustomPopup(popupData);
        }

        /// <summary>
        /// Close the popup window if it was active by this display system.
        /// </summary>
        /// <param name="popupHandle">The popup window to close.</param>
        public static void ClosePopup(IPopupHandle popupHandle)
        {
            root.displaySystem.ClosePopup(popupHandle);
        }

        private IPopupDisplaySystem displaySystem;

        private void Awake()
        {
            if (root != null)
            {
                Log.Warning(gameObject, $"There are multiple popup systems active simultaneously! This one will be destroyed.");
                Destroy(this);
                return;
            }

            root = this;
            displaySystem = GetComponent<IPopupDisplaySystem>();
        }

        private void OnDestroy()
        {
            if (root == this)
            {
                root = null;
            }
        }
    }
}
