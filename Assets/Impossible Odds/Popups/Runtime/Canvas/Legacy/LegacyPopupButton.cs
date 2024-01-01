using System;
using UnityEngine;
using UnityEngine.UI;

namespace ImpossibleOdds.Popups.Canvas.Legacy
{
    [RequireComponent(typeof(Button))]
    public class LegacyPopupButton : MonoBehaviour
    {
        public event Action onButtonClicked;
        
        [SerializeField]
        private Text text;
        [SerializeField]
        private Image icon;

        private PopupButton buttonInfo;

        private Button Button => GetComponent<Button>();

        public PopupButton ButtonInfo
        {
            get => buttonInfo;
            set
            {
                buttonInfo = value;

                if (text != null)
                {
                    if (!buttonInfo.text.IsNullOrEmpty())
                    {
                        text.text = buttonInfo.text;
                    }
                    else
                    {
                        text.gameObject.SetActive(false);
                    }
                }

                if (icon != null)
                {
                    if (buttonInfo.icon != null)
                    {
                        icon.sprite = buttonInfo.icon;
                    }
                    else
                    {
                        icon.gameObject.SetActive(false);
                    }
                }
            }
        }

        private void Awake()
        {
            Button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            buttonInfo.onClickAction.InvokeIfNotNull();
            onButtonClicked.InvokeIfNotNull();
        }
    }
}

