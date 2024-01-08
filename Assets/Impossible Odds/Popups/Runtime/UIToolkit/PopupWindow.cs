using System;
using UnityEngine.UIElements;

namespace ImpossibleOdds.Popups.UIToolkit
{
    public abstract class PopupWindow : IUIToolkitPopupWindow
    {
        public event Action onHidePopup;

        private VisualElement visualElement;

        public PopupWindow(VisualElement visualElement)
        {
            visualElement.ThrowIfNull(nameof(visualElement));
            this.visualElement = visualElement;
        }

        /// <inheritdoc />
        public VisualElement PopupObject => visualElement;

        /// <summary>
        /// The header text of the popup window.
        /// </summary>
        public abstract string Header
        {
            get;
            set;
        }

        protected void CallOnHidePopup()
        {
            onHidePopup.InvokeIfNotNull();
        }
    }
}
