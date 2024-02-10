using System;
using System.Collections.Generic;
using UnityEngine;

namespace ImpossibleOdds.Popups.Canvas
{
    /// <summary>
    /// A popup display system based on the Unity UI Canvas system.
    /// </summary>
    [RequireComponent(typeof(UnityEngine.Canvas)), AddComponentMenu("Impossible Odds/Popups/Canvas/Popup Display System")]
    public class PopupDisplaySystem : MonoBehaviour, IPopupDisplaySystem
    {
        [SerializeField, Tooltip("The parent object for popup windows spawned by this display system.")]
        private RectTransform popupParent;
        [SerializeField, Tooltip("The popup window prefab.")]
        private PopupWindow popupWindowPrefab;
        [SerializeField, Tooltip("The prefab for simple popup contents.")]
        private SimplePopupContents simplePopupContentsPrefab;

        private UnityEngine.Canvas canvas;

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
        public IPopupHandle ShowSimplePopup(SimplePopupDescription popupDescription)
        {
            SimplePopupContents contents = Instantiate(simplePopupContentsPrefab);
            contents.SetContents(popupDescription.Contents);
            contents.SetButtons(popupDescription.Buttons);

            PopupWindow popupWindow = Instantiate(popupWindowPrefab, popupParent);
            popupWindow.Initialize(contents, this);
            popupWindow.SetHeader(popupDescription.Header);
            popupWindow.SetContents(contents.transform as RectTransform);
            popupWindow.onClosePopup += ClosePopup;

            activePopups.Add(popupWindow);

            canvas.enabled = true;

            return popupWindow;
        }

        /// <inheritdoc />
        public IPopupHandle ShowCustomPopup(Popups.ICustomPopupContents popupDescription)
        {
            popupDescription.ThrowIfNull(nameof(popupDescription));

            if (popupDescription is not ICustomPopupContents customPopupData)
            {
                throw new ArgumentException($"This {nameof(PopupDisplaySystem)} can only display popups that implement the {nameof(ICustomPopupContents)} interface.");
            }

            PopupWindow popupWindow = Instantiate(popupWindowPrefab, popupParent);
            popupWindow.Initialize(customPopupData, this);
            popupWindow.SetHeader(customPopupData.Header);
            popupWindow.SetContents(customPopupData.ContentsRoot);
            popupWindow.onClosePopup += ClosePopup;
            
            activePopups.Add(popupWindow);

            canvas.enabled = true;
            
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

            canvas.enabled = IsShowingPopups();
        }

        private void Awake()
        {
            canvas = GetComponent<UnityEngine.Canvas>();
            canvas.enabled = false;
        }
    }
}

