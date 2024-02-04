using System;
using System.Collections;
using UnityEngine;

namespace ImpossibleOdds.Popups.Canvas
{
    /// <summary>
    /// An abstract popup window class for the canvas-based popup display system, to be further defined in both the legacy UI and Text Mesh Pro systems.
    /// </summary>
    public abstract class PopupWindow : MonoBehaviour, IPopupHandle
    {
        public event Action<IPopupHandle> onClosePopup;
        
        [SerializeField, Tooltip("All content will be placed behind this transform in the popup window.")]
        private RectTransform contentsSibling;

        private IPopupDisplaySystem displaySystem;
        private IPopupContents popupContents;

        /// <inheritdoc />
        public Popups.IPopupContents PopupContents => popupContents;

        /// <inheritdoc />
        public IPopupDisplaySystem DisplaySystem => displaySystem;

        /// <summary>
        /// Initializes the popup window.
        /// </summary>
        /// <param name="popupContents">The popup contents object.</param>
        /// <param name="displaySystem">The display system this popup window belongs to.</param>
        public void Initialize(IPopupContents popupContents, IPopupDisplaySystem displaySystem)
        {
            popupContents.ThrowIfNull(nameof(popupContents));
            displaySystem.ThrowIfNull(nameof(displaySystem));

            this.popupContents = popupContents;
            this.displaySystem = displaySystem;

            popupContents.onClosePopup += OnClosePopup;
        }
        
        /// <summary>
        /// Sets the header text of the popup window.
        /// </summary>
        /// <param name="header">The header text of the popup window</param>
        public abstract void SetHeader(string header);

        /// <summary>
        /// Attaches the actual contents of the popup to the popup window.
        /// </summary>
        /// <param name="contents">The contents of the popup window.</param>
        public virtual void SetContents(RectTransform contents)
        {
            contents.ThrowIfNull(nameof(contents));
            
            contents.SetParent(contentsSibling.parent, false);
            contents.SetSiblingIndex(contentsSibling.GetSiblingIndex() + 1);
        }

        private void OnClosePopup()
        {
            onClosePopup.InvokeIfNotNull(this);
        }

        #region IEnumerator
        bool IEnumerator.MoveNext() => ((IPopupHandle)this).IsShowing;
        void IEnumerator.Reset() => throw new System.NotImplementedException();
        object IEnumerator.Current => this;
        #endregion
    }
}

