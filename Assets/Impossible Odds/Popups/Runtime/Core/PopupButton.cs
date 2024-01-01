using System;
using UnityEngine;

namespace ImpossibleOdds.Popups
{
    [Serializable]
    public struct PopupButton
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

