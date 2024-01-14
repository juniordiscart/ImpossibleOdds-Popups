using UnityEngine;

namespace ImpossibleOdds.Popups
{
    [RequireComponent(typeof(IPopupDisplaySystem)), AddComponentMenu("Impossible Odds/Popups/Popup System")]
    public class Popup : MonoBehaviour
    {
        private static Popup root;

        public static PopupHandle ShowNotification(NotificationPopupDescription popupData)
        {
            return root.displaySystem.ShowNotification(popupData);
        }

        public static PopupHandle ShowConfirmation(ConfirmationPopupDescription popupData)
        {
            return root.displaySystem.ShowConfirmation(popupData);
        }

        public static PopupHandle ShowComplex(ComplexPopupDescription popupData)
        {
            return root.displaySystem.ShowComplexPopup(popupData);
        }

        public static PopupHandle ShowCustom(IPopupWindow popupWindow)
        {
            return root.displaySystem.ShowCustomPopup(popupWindow);
        }

        public static void ClosePopup(PopupHandle popupHandle)
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

