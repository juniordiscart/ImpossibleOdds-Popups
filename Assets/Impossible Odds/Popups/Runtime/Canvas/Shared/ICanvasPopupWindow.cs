using UnityEngine;

namespace ImpossibleOdds.Popups.Canvas
{
    public interface ICanvasPopupWindow : IPopupWindow
    {
        /// <summary>
        /// A handle to the actual popup transform.
        /// </summary>
        GameObject PopupObject
        {
            get;
        }
        
        /// <summary>
        /// Should this popup window be destroyed when it is taken down from the popup display system?
        /// </summary>
        bool DestroyPopupWindowOnHide
        {
            get;
        }
    }
    
}

