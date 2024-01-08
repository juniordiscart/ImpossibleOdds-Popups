using System;
using UnityEngine;

namespace ImpossibleOdds.Popups.Canvas
{
    public abstract class PopupWindow : MonoBehaviour, ICanvasPopupWindow
    {
        /// <inheritdoc />
        public event Action onHidePopup;

        /// <inheritdoc />
        public GameObject PopupObject => gameObject;
        
        /// <inheritdoc />
        public abstract bool DestroyPopupWindowOnHide
        {
            get;
        }
        
        /// <summary>
        /// The header text of the popup window.
        /// </summary>
        public abstract string Header
        {
            get;
            set;
        }

        /// <summary>
        /// Call the onHidePopup event.
        /// </summary>
        protected void CallOnHidePopup()
        {
            onHidePopup.InvokeIfNotNull();
        }
    }
}

