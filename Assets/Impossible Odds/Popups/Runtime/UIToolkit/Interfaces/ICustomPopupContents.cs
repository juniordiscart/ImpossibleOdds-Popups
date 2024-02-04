using UnityEngine.UIElements;

namespace ImpossibleOdds.Popups.UIToolkit
{
    public interface ICustomPopupContents : ImpossibleOdds.Popups.ICustomPopupContents
    {
        VisualElement ContentsRoot
        {
            get;
        }
    }
}

