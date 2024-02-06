using UnityEngine;

namespace ImpossibleOdds.Popups.Canvas
{
    /// <summary>
    /// The interface for custom popup contents to be displayed in the Canvas display system.
    /// </summary>
    public interface ICustomPopupContents : ImpossibleOdds.Popups.ICustomPopupContents, IPopupContents
    {
        /// <summary>
        /// The root of the contents of this popup. This object will be attached to the popup window.
        /// </summary>
        RectTransform ContentsRoot
        {
            get;
        }
    }
}

