using System;
using UnityEngine;

namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// A popup button description to display the button's text, icon and the action to take when clicked.
    /// </summary>
    [Serializable]
    public struct PopupButtonDescription
    {
        /// <summary>
        /// The icon on the button.
        /// </summary>
        public Sprite icon;
        /// <summary>
        /// The text on the button.
        /// </summary>
        public string text;
        /// <summary>
        /// The action on the button.
        /// </summary>
        public Action onClickAction;
    }
}

