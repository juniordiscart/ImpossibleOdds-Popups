using System.Collections;

namespace ImpossibleOdds.Popups
{
    public class PopupHandle : IEnumerator
    {
        private IPopupWindow popupWindow;
        private IPopupDisplaySystem displaySystem;

        public PopupHandle(IPopupWindow window, IPopupDisplaySystem displaySystem)
        {
            window.ThrowIfNull(nameof(window));
            displaySystem.ThrowIfNull(nameof(displaySystem));
            
            this.popupWindow = window;
            this.displaySystem = displaySystem;
        }

        /// <summary>
        /// A reference to the popup window.
        /// </summary>
        public IPopupWindow PopupWindow => popupWindow;

        /// <summary>
        /// Is the popup still being shown by the popup display system?
        /// </summary>
        public bool IsShowing => displaySystem.IsShowingPopup(this);
        
        bool IEnumerator.MoveNext()
        {
            return IsShowing;
        }
        
        void IEnumerator.Reset()
        {
            throw new System.NotImplementedException(nameof(IEnumerator.Reset));
        }
        
        object IEnumerator.Current => PopupWindow;
    }
}

