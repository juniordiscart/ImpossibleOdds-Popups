using TMPro;
using UnityEngine;

namespace ImpossibleOdds.Popups.Canvas.TextMeshPro
{
    /// <summary>
    /// A Popup window frame using Text Mesh Pro components.
    /// </summary>
    [AddComponentMenu("Impossible Odds/Popups/Canvas/Text Mesh Pro/Popup Window")]
    public class PopupWindow : ImpossibleOdds.Popups.Canvas.PopupWindow
    {
        [SerializeField]
        private TMP_Text header;

        /// <inheritdoc />
        public override void SetHeader(string header)
        {
            this.header.text = header;
        }
    }
}
