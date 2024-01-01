using System;
using UnityEngine;

namespace ImpossibleOdds.Popups.Canvas
{
    public abstract class CanvasPopupWindow : MonoBehaviour, IPopupWindow
    {
        /// <inheritdoc />
        public event Action onHidePopup;
        
        /// <inheritdoc />
        public abstract string Header
        {
            get;
            set;
        }

        /// <inheritdoc />
        public abstract bool DestroyPopupWindowOnHide
        {
            get;
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

