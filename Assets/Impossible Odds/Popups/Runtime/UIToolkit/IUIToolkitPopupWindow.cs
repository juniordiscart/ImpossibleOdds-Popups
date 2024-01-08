using UnityEngine.UIElements;

namespace ImpossibleOdds.Popups.UIToolkit
{
    public interface IUIToolkitPopupWindow : IPopupWindow
    {
        /// <summary>
        /// A handle to the actual popup visual element in the document.
        /// </summary>
        VisualElement PopupObject
        {
            get;
        }
    }
}

