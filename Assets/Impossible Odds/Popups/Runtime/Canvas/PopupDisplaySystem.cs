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
        private PopupWindow popupWindowPrefab;
        [SerializeField]
        private PopupDefaultContents popupDefaultContentsPrefab;

        private readonly List<PopupWindow> activePopups = new List<PopupWindow>();

        /// <inheritdoc />
        public bool IsShowingPopups()
        {
            return activePopups.Count > 0;
        }
        
        /// <inheritdoc />
        public bool IsShowingPopup(IPopupHandle popupHandle)
        {
            popupHandle.ThrowIfNull(nameof(popupHandle));
            return (popupHandle is PopupWindow pw) && activePopups.Contains(pw);
        }

        /// <inheritdoc />
        public IPopupHandle ShowNotification(NotificationPopupDescription notificationData)
        {
            return ShowDefaultPopup(notificationData);
        }

        /// <inheritdoc />
        public IPopupHandle ShowConfirmation(ConfirmationPopupDescription confirmationData)
        {
            return ShowDefaultPopup(confirmationData);
        }

        /// <inheritdoc />
        public IPopupHandle ShowComplexPopup(ComplexPopupDescription complexData)
        {
            return ShowDefaultPopup(complexData);
        }

        /// <inheritdoc />
        public IPopupHandle ShowCustomPopup(Popups.ICustomPopupDescription popupDescription)
        {
            popupDescription.ThrowIfNull(nameof(popupDescription));

            if (popupDescription is not ICustomPopupDescription customPopupData)
            {
                throw new ArgumentException($"This {nameof(PopupDisplaySystem)} can only display popups that implement the {nameof(ICustomPopupDescription)} interface.");
            }

            ICustomPopupContents popupContents = customPopupData.GetPopupContents();

            PopupWindow popupWindow = Instantiate(popupWindowPrefab, popupParent);
            popupWindow.Initialize(popupContents, this);
            popupWindow.SetHeader(popupContents.Header);
            popupWindow.SetContents(popupContents.ContentsRoot);
            popupWindow.onClosePopup += ClosePopup;
            
            activePopups.Add(popupWindow);
            
            inputBlocker.gameObject.SetActive(true);
            popupParent.gameObject.SetActive(true);
            
            return popupWindow;
        }

        /// <inheritdoc />
        public void ClosePopup(IPopupHandle popupHandle)
        {
            popupHandle.ThrowIfNull(nameof(popupHandle));

            // If the popup handle is not of the expected type, or
            // the popup is not being handled by this popup display system.
            if ((popupHandle is not PopupWindow popupWindow) || !activePopups.Remove(popupWindow))
            {
                return;
            }

            // Remove the popup from the canvas.
            popupWindow.transform.SetParent(null);

            if (popupWindow.PopupContents is IPopupContents { DestroyAfterClose: true })
            {
                popupWindow.gameObject.SetActive(false);
                Destroy(popupWindow.gameObject);
            }
            
            inputBlocker.gameObject.SetActive(IsShowingPopups());
            popupParent.gameObject.SetActive(IsShowingPopups());
        }

        private void Awake()
        {
            inputBlocker.gameObject.SetActive(activePopups.Count > 0);
            popupParent.gameObject.SetActive(activePopups.Count > 0);
        }

        private PopupWindow ShowDefaultPopup(IDefaultPopupDescription description)
        {
            PopupDefaultContents defaultContents = Instantiate(popupDefaultContentsPrefab);
            defaultContents.SetContents(description.Contents);
            defaultContents.SetButtons(description.Buttons);
            
            PopupWindow popupWindow = Instantiate(popupWindowPrefab, popupParent);
            popupWindow.Initialize(defaultContents, this);
            popupWindow.SetHeader(description.Header);
            popupWindow.SetContents(defaultContents.transform as RectTransform);
            popupWindow.onClosePopup += ClosePopup;
            
            activePopups.Add(popupWindow);
            
            inputBlocker.gameObject.SetActive(true);
            popupParent.gameObject.SetActive(true);

            return popupWindow;
        }
    }
}

