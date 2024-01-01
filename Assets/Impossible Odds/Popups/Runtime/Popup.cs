using UnityEngine;

namespace ImpossibleOdds.Popups
{
    [RequireComponent(typeof(IPopupDisplaySystem))]
    public class Popup : MonoBehaviour
    {
        private static Popup root;

        public static IPopupWindow ShowNotification(NotificationPopup popupData)
        {
            return root.displaySystem.ShowNotification(popupData);
        }

        public static IPopupWindow ShowConfirmation(ConfirmationPopup popupData)
        {
            return root.displaySystem.ShowConfirmation(popupData);
        }

        public static IPopupWindow ShowComplex(ComplexPopup popupData)
        {
            return root.displaySystem.ShowComplexPopup(popupData);
        }

        public static IPopupWindow ShowCustom(IPopupWindow popupWindow)
        {
            return root.displaySystem.ShowCustomPopup(popupWindow);
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

