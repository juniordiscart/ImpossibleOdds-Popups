using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ImpossibleOdds.Popups.UIToolkit
{
    [RequireComponent(typeof(UIDocument)), AddComponentMenu("Impossible Odds/Popups/UI Toolkit/Popup Display System")]
    public class PopupDisplaySystem : MonoBehaviour, IPopupDisplaySystem
    {
        [SerializeField]
        private string popupParentName = "PopupRoot";
        [SerializeField]
        private DefaultPopupWindowConfiguration defaultPopupWindowConfiguration;

        private UIDocument document;

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

            if (popupWindow is not IUIToolkitPopupWindow uiToolkitPopupWindow)
            {
                throw new ArgumentException($"This {nameof(PopupDisplaySystem)} can only display custom popups that implement the {nameof(IUIToolkitPopupWindow)} interface.");
            }

            // Check that this popup window is not already being used in another popup handle handled by this display system.
            if (activePopups.TryFind(ph => ph.PopupWindow == popupWindow, out PopupHandle existingHandle))
            {
                return existingHandle;
            }

            document.rootVisualElement.Q(popupParentName).Add(uiToolkitPopupWindow.PopupObject);
            document.rootVisualElement.SetEnabled(true);

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

            if (popupHandle.PopupWindow is IUIToolkitPopupWindow uiToolkitPopupWindow)
            {
                document.rootVisualElement.Q(popupParentName).Remove(uiToolkitPopupWindow.PopupObject);
            }

            document.rootVisualElement.style.display = IsShowingPopup() ? DisplayStyle.Flex : DisplayStyle.None;
            document.rootVisualElement.SetEnabled(IsShowingPopup());
        }

        private PopupHandle ShowDefaultPopup(IPopupDescription description)
        {
            TemplateContainer container = defaultPopupWindowConfiguration.popupWindowTreeAsset.Instantiate();
            VisualElement popupParent = document.rootVisualElement.Q(popupParentName);
            DefaultPopupWindow popupWindow = new DefaultPopupWindow(container, defaultPopupWindowConfiguration)
            {
                Header = description.Header,
                Contents = description.Contents
            };

            popupWindow.SetButtons(description.Buttons);
            popupParent.Add(container);

            PopupHandle handle = new PopupHandle(popupWindow, this);
            popupWindow.onHidePopup += () => ClosePopup(handle);
            activePopups.Add(handle);

            document.rootVisualElement.style.display = DisplayStyle.Flex;
            document.rootVisualElement.SetEnabled(true);

            popupParent.Q<Button>().Focus();

            return handle;
        }

        private void Awake()
        {
            document = GetComponent<UIDocument>();

            // Hide and disable the input blocker and popup parent.
            document.rootVisualElement.style.display = DisplayStyle.None;
            document.rootVisualElement.SetEnabled(false);
        }
    }
}
