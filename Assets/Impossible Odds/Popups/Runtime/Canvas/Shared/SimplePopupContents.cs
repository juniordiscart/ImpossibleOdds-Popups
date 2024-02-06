using System;
using System.Collections.Generic;
using UnityEngine;

namespace ImpossibleOdds.Popups.Canvas
{
    public abstract class SimplePopupContents : MonoBehaviour, IPopupContents
    {
        /// <inheritdoc />
        public event Action onClosePopup;

        /// <inheritdoc />
        public bool DestroyAfterClose => true;
        
        /// <summary>
        /// Sets the textual information for this popup.
        /// </summary>
        /// <param name="contents">The textual information to display.</param>
        public abstract void SetContents(string contents);
        
        /// <summary>
        /// Spawns the buttons for this popup.
        /// </summary>
        /// <param name="buttons">The button descriptions to display on the popup.</param>
        public abstract void SetButtons(IEnumerable<PopupButtonDescription> buttons);
        
        protected void OnClosePopup()
        {
            onClosePopup.InvokeIfNotNull();
        }
    }
}

