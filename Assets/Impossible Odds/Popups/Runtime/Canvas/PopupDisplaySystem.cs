using System;
using System.Collections.Generic;
using UnityEngine;

namespace ImpossibleOdds.Popups.Canvas
{
    /// <summary>
    /// A popup display system based on the Unity UI Canvas system.
    /// </summary>
    [AddComponentMenu("Impossible Odds/Popups/Canvas/Popup Display System")]
    public class PopupDisplaySystem : MonoBehaviour, IPopupDisplaySystem
    {
        [SerializeField]
        private RectTransform inputBlocker;
        [SerializeField]
        private RectTransform popupParent;

        [SerializeField]
        private DefaultPopupWindow popupWindowPrefab;

        private readonly List<PopupHandle> activePopups = new List<PopupHandle>();

        /// <inheritdoc />
        public bool IsShowingPopup()
        {
            return activePopups.Count > 0;
        }
        
        /// <inheritdoc />
        public bool IsShowingPopup(PopupHandle popupHandle)
        {
            popupHandle.ThrowIfNull(nameof(popupHandle));
            return activePopups.Contains(popupHandle);
        }

        /// <inheritdoc />
        public PopupHandle ShowNotification(NotificationPopupDescription notificationData)
        {
            return ShowDefaultPopup(notificationData);
        }

        /// <inheritdoc />
        public PopupHandle ShowConfirmation(ConfirmationPopupDescription confirmationData)
        {
            return ShowDefaultPopup(confirmationData);
        }

        /// <inheritdoc />
        public PopupHandle ShowComplexPopup(ComplexPopupDescription complexData)
        {
            return ShowDefaultPopup(complexData);
        }

        /// <inheritdoc />
        public PopupHandle ShowCustomPopup(IPopupWindow popupWindow)
        {
            popupWindow.ThrowIfNull(nameof(popupWindow));

            if (popupWindow is not ICanvasPopupWindow canvasPopup)
            {
                throw new ArgumentException($"This {nameof(PopupDisplaySystem)} can only display popups that implement the {nameof(ICanvasPopupWindow)} interface.");
            }
            
            // Check that this popup window is not already being used in another popup handle handled by this display system.
            if (activePopups.TryFind(ph => ph.PopupWindow == popupWindow, out PopupHandle existingHandle))
            {
                return existingHandle;
            }

            canvasPopup.PopupObject.transform.SetParent(popupParent);
            
            PopupHandle handle = new PopupHandle(popupWindow, this);
            popupWindow.onHidePopup += ClosePopupAndCleanup;
            activePopups.Add(handle);
            return handle;

            void ClosePopupAndCleanup()
            {
                popupWindow.onHidePopup -= ClosePopupAndCleanup;
                ClosePopup(handle);
            }
        }

        /// <inheritdoc />
        public void ClosePopup(PopupHandle popupHandle)
        {
            popupHandle.ThrowIfNull(nameof(popupHandle));
            
            if (!activePopups.Remove(popupHandle))
            {
                return;
            }

            if (popupHandle.PopupWindow is ICanvasPopupWindow canvasPopupWindow)
            {
                canvasPopupWindow.PopupObject.transform.SetParent(null);

                if (canvasPopupWindow.DestroyPopupWindowOnHide)
                {
                    canvasPopupWindow.PopupObject.SetActive(false);
                    Destroy(canvasPopupWindow.PopupObject);
                }
            }
            
            inputBlocker.gameObject.SetActive(IsShowingPopup());
            popupParent.gameObject.SetActive(IsShowingPopup());
        }

        private void Awake()
        {
            inputBlocker.gameObject.SetActive(activePopups.Count > 0);
            popupParent.gameObject.SetActive(activePopups.Count > 0);
        }

        private PopupHandle ShowDefaultPopup(IPopupDescription description)
        {
            DefaultPopupWindow popupWindow = Instantiate(popupWindowPrefab, popupParent);
            popupWindow.Header = description.Header;
            popupWindow.Contents = description.Contents;
            popupWindow.SetButtons(description.Buttons);

            PopupHandle handle = new PopupHandle(popupWindow, this);
            popupWindow.onHidePopup += () => ClosePopup(handle);
            activePopups.Add(handle);
            
            inputBlocker.gameObject.SetActive(true);
            popupParent.gameObject.SetActive(true);

            return handle;
        }
    }
}

