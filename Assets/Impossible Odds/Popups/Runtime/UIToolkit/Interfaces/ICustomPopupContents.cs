using UnityEngine.UIElements;

namespace ImpossibleOdds.Popups.UIToolkit
{
    /// <summary>
    /// The interface for custom popup contents to be displayed in the UI Toolkit display system.
    /// </summary>
    public interface ICustomPopupContents : ImpossibleOdds.Popups.ICustomPopupContents
    {
        /// <summary>
        /// The root element of the popup contents. These contents will be moved to the popup window's visual tree.
        /// </summary>
        VisualElement ContentsRoot
        {
            get;
        }
    }
}

