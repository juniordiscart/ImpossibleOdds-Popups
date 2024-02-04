using UnityEngine;
using UnityEngine.UI;

namespace ImpossibleOdds.Popups.Canvas.Legacy
{
    /// <summary>
    /// A Popup window frame using Unity's legacy UI component system.
    /// </summary>
    [AddComponentMenu("Impossible Odds/Popups/Canvas/Legacy/Popup Window")]
    public class PopupWindow : ImpossibleOdds.Popups.Canvas.PopupWindow
    {
        [SerializeField]
        private Text header;

        /// <inheritdoc />
        public override void SetHeader(string header)
        {
            this.header.text = header;
        }
    }
}

