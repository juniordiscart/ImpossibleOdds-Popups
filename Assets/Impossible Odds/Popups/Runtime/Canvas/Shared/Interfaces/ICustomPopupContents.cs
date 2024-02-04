using UnityEngine;

namespace ImpossibleOdds.Popups.Canvas
{
    public interface ICustomPopupContents : ImpossibleOdds.Popups.ICustomPopupContents, IPopupContents
    {
        /// <summary>
        /// The root of the contents of this popup.
        /// </summary>
        RectTransform ContentsRoot
        {
            get;
        }
    }
}

