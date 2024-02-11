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
        /// Shows a simple textual popup with zero, one or more options.
        /// Note: if no options are given to the user to interact with the popup, it's the caller's responsibility to dismiss the popup.
        /// </summary>
        /// <param name="popupDescription">The description of the popup to display.</param>
        /// <returns>A handle to the popup window.</returns>
        public static IPopupHandle ShowSimplePopup(SimplePopupDescription popupDescription)
        {
            return root.displaySystem.ShowSimplePopup(popupDescription);
        }

        /// <summary>
        /// Shows a custom popup window in the display system.
        /// </summary>
        /// <param name="popupData">The popup data to show in this popup display system.</param>
        /// <returns>A handle to the popup window.</returns>
        public static IPopupHandle ShowCustom(ICustomPopupContents popupData)
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
