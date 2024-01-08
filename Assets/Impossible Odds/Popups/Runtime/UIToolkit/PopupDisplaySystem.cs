using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ImpossibleOdds.Popups.UIToolkit
{
    [RequireComponent(typeof(UIDocument))]
    public class PopupDisplaySystem : MonoBehaviour, IPopupDisplaySystem
    {
        [SerializeField]
        private string inputBlockerName = "InputBlocker";
        [SerializeField]
        private string popupParentName = "PopupRoot";
        [SerializeField]
        private DefaultPopupWindowConfiguration defaultPopupWindowConfiguration;

        private UIDocument document;
        private VisualElement inputBlocker;
        private VisualElement popupParent;
        
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
            
            popupParent.Add(uiToolkitPopupWindow.PopupObject);
            
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
                popupParent.Remove(uiToolkitPopupWindow.PopupObject);
            }
            
            bool isAnyPopupActive = IsShowingPopup(); 
            inputBlocker.visible = isAnyPopupActive;
            inputBlocker.SetEnabled(isAnyPopupActive);

            popupParent.visible = isAnyPopupActive;
            popupParent.SetEnabled(isAnyPopupActive);
        }

        private PopupHandle ShowDefaultPopup(IPopupDescription description)
        {
            TemplateContainer container = defaultPopupWindowConfiguration.popupWindowTreeAsset.Instantiate();
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
            
            inputBlocker.visible = true;
            inputBlocker.SetEnabled(true);

            popupParent.visible = true;
            popupParent.SetEnabled(true);
            
            popupParent.Q<Button>().Focus();

            return handle;
        }
        
        private void Awake()
        {
            document = GetComponent<UIDocument>();
            inputBlocker = document.rootVisualElement.Q(inputBlockerName);
            popupParent = document.rootVisualElement.Q(popupParentName);

            inputBlocker.visible = false;
            inputBlocker.SetEnabled(false);

            popupParent.visible = false;
            popupParent.SetEnabled(false);
        }
    }
}

