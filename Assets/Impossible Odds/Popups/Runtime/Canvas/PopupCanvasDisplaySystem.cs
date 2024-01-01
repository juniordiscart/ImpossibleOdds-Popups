using System;
using System.Collections.Generic;
using ImpossibleOdds.Popups.Canvas;
using UnityEngine;

namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// A popup display system based on the Unity UI Canvas system.
    /// </summary>
    public class PopupCanvasDisplaySystem : MonoBehaviour, IPopupDisplaySystem
    {
        [SerializeField]
        private RectTransform inputBlocker;
        [SerializeField]
        private RectTransform root;

        [SerializeField]
        private CanvasDefaultPopupWindow popupWindowPrefab;

        private readonly HashSet<IPopupWindow> activePopups = new HashSet<IPopupWindow>();

        /// <inheritdoc />
        public IPopupWindow ShowNotification(NotificationPopup notificationData)
        {
            return ShowDefaultPopup(notificationData);
        }

        /// <inheritdoc />
        public IPopupWindow ShowConfirmation(ConfirmationPopup confirmationData)
        {
            return ShowDefaultPopup(confirmationData);
        }

        /// <inheritdoc />
        public IPopupWindow ShowComplexPopup(ComplexPopup complexData)
        {
            return ShowDefaultPopup(complexData);
        }

        /// <inheritdoc />
        public IPopupWindow ShowCustomPopup(IPopupWindow popupWindow)
        {
            popupWindow.ThrowIfNull(nameof(popupWindow));

            if (popupWindow is not Component)
            {
                throw new ArgumentException($"The {nameof(PopupCanvasDisplaySystem)} can only display popup windows that are work with Unity's {nameof(Component)} system.", nameof(popupWindow));
            }

            if (!activePopups.Add(popupWindow))
            {
                return popupWindow;
            }

            popupWindow.onHidePopup += ClosePopupAndCleanup;
            return popupWindow;

            void ClosePopupAndCleanup()
            {
                popupWindow.onHidePopup -= ClosePopupAndCleanup;
                ClosePopup(popupWindow);
            }
        }

        /// <inheritdoc />
        public void ClosePopup(IPopupWindow popupWindow)
        {
            popupWindow.ThrowIfNull(nameof(popupWindow));
            
            if (!activePopups.Remove(popupWindow))
            {
                return;
            }

            if (popupWindow.DestroyPopupWindowOnHide && (popupWindow is Component popupComponent))
            {
                Destroy(popupComponent.gameObject);
            }
            
            inputBlocker.gameObject.SetActive(activePopups.Count > 0);
            root.gameObject.SetActive(activePopups.Count > 0);
        }

        private void Awake()
        {
            inputBlocker.gameObject.SetActive(activePopups.Count > 0);
        }

        private IPopupWindow ShowDefaultPopup(IPopupDescription description)
        {
            CanvasDefaultPopupWindow popupWindow = Instantiate(popupWindowPrefab, root);
            popupWindow.Header = description.Header;
            popupWindow.Contents = description.Contents;
            popupWindow.SetButtons(description.Buttons);
            popupWindow.onHidePopup += () => ClosePopup(popupWindow);

            activePopups.Add(popupWindow);
            
            inputBlocker.gameObject.SetActive(true);
            root.gameObject.SetActive(true);

            return popupWindow;
        }
    }
}

