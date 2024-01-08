using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ImpossibleOdds.Popups.UIToolkit
{
    [Serializable]
    public struct DefaultPopupWindowConfiguration
    {
        [SerializeField]
        public string headerName;
        [SerializeField]
        public string contentsName;
        [SerializeField]
        public string buttonsRootName;

        [SerializeField]
        public VisualTreeAsset popupWindowTreeAsset;
        [SerializeField]
        public VisualTreeAsset buttonTreeAsset;
    }
}

