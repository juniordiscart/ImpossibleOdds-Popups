using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ImpossibleOdds.Popups.UIToolkit
{
    /// <summary>
    /// The UI Toolkit-based popup display system.
    /// </summary>
    [RequireComponent(typeof(UIDocument)), AddComponentMenu("Impossible Odds/Popups/UI Toolkit/Popup Display System")]
    public class PopupDisplaySystem : MonoBehaviour, IPopupDisplaySystem
    {
        [SerializeField, Tooltip("The name of the element where popup windows will attached to.")]
        private string popupParentName = "PopupRoot";
        [SerializeField, Tooltip("Configuration values to create and configure popup windows spawned by the display system.")]
        private PopupWindowConfiguration popupWindowConfiguration;
        [SerializeField, Tooltip("Configuration values to spawn and create simple popups.")]
        private DefaultPopupContentsConfiguration simplePopupContentsConfiguration;

        private UIDocument document;

        private readonly List<PopupWindow> activePopups = new List<PopupWindow>();

        private VisualElement PopupParent => document.rootVisualElement.Q(popupParentName);

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

            if (popupDescription is not ICustomPopupDescription uitkPopupDescription)
            {
                throw new ArgumentException($"This {nameof(PopupDisplaySystem)} can only display custom popups that implement the {nameof(ICustomPopupDescription)} interface.");
            }
            
            ICustomPopupContents popupContents = uitkPopupDescription.GetPopupContents();
            
            PopupWindow window = CreatePopupWindow(popupContents);
            window.SetHeader(popupContents.Header);
            
            VisualElement popupContentsRoot = popupContents.ContentsRoot;
            if (popupContentsRoot is TemplateContainer templateContainer)
            {
                window.SetContents(templateContainer);
            }
            else
            {
                window.SetContents(popupContentsRoot);
            }
            
            window.onClosePopup += ClosePopup;
            
            activePopups.Add(window);
            return window;
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

            if (PopupParent.Contains(popupWindow.WindowElement))
            {
                PopupParent.Remove(popupWindow.WindowElement);
            }

            document.enabled = IsShowingPopups();
        }

        private PopupWindow ShowDefaultPopup(ISimplePopupDescription description)
        {
            TemplateContainer defaultTreeContents = simplePopupContentsConfiguration.contentsTreeAsset.Instantiate();
            SimplePopupContents simplePopupContents = new SimplePopupContents(
                defaultTreeContents.Q<TextElement>(simplePopupContentsConfiguration.contentsName),
                defaultTreeContents.Q(simplePopupContentsConfiguration.buttonsRootName),
                simplePopupContentsConfiguration.buttonTreeAsset);
            
            simplePopupContents.SetContents(description.Contents);
            simplePopupContents.SetButtons(description.Buttons);
            
            PopupWindow window = CreatePopupWindow(simplePopupContents);
            window.SetHeader(description.Header);
            window.SetContents(defaultTreeContents);
            window.onClosePopup += ClosePopup;
            
            activePopups.Add(window);

            return window;
        }

        private void Awake()
        {
            document = GetComponent<UIDocument>();
        }

        private PopupWindow CreatePopupWindow(IPopupContents popupContents)
        {
            document.enabled = true;
            popupWindowConfiguration.windowTreeAsset.CloneTree(PopupParent, out int firstElementIndex, out int elementAddedCount);

            if (elementAddedCount != 1)
            {
                throw new ArgumentOutOfRangeException(nameof(elementAddedCount), "The popup display system expects only a single root element when creating a popup window.");
            }

            VisualElement popupWindowElement = PopupParent[firstElementIndex];

            return new PopupWindow(
                this,
                popupContents,
                popupWindowElement,
                popupWindowElement.Q<TextElement>(popupWindowConfiguration.headerName),
                popupWindowElement.Q(popupWindowConfiguration.contentSiblingName));
        }
        
        [Serializable]
        private class DefaultPopupContentsConfiguration
        {
            [SerializeField]
            public string contentsName;
            [SerializeField]
            public string buttonsRootName;

            [SerializeField]
            public VisualTreeAsset contentsTreeAsset;
            [SerializeField]
            public VisualTreeAsset buttonTreeAsset;
        }
        
        [Serializable]
        private class PopupWindowConfiguration
        {
            [SerializeField]
            public string headerName;
            [SerializeField]
            public string contentSiblingName;
            [SerializeField]
            public VisualTreeAsset windowTreeAsset;
        }
    }
}
