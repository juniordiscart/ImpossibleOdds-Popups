using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ImpossibleOdds.Popups.Canvas.TextMeshPro
{
    /// <summary>
    /// A popup button script for display with Text Mesh Pro components.
    /// </summary>
    [RequireComponent(typeof(Button)), AddComponentMenu("Impossible Odds/Popups/Canvas/Text Mesh Pro/Popup Button")]
    public class PopupButton : MonoBehaviour
    {
        public event Action onButtonClicked;
        
        [SerializeField]
        private TMP_Text text;
        [SerializeField]
        private Image icon;

        private PopupButtonDescription m_ButtonDescriptionInfo;

        private Button Button => GetComponent<Button>();

        public PopupButtonDescription ButtonDescriptionInfo
        {
            get => m_ButtonDescriptionInfo;
            set
            {
                m_ButtonDescriptionInfo = value;

                if (text != null)
                {
                    if (!m_ButtonDescriptionInfo.text.IsNullOrEmpty())
                    {
                        text.text = m_ButtonDescriptionInfo.text;
                    }
                    else
                    {
                        text.gameObject.SetActive(false);
                    }
                }

                if (icon != null)
                {
                    if (m_ButtonDescriptionInfo.icon != null)
                    {
                        icon.sprite = m_ButtonDescriptionInfo.icon;
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
            m_ButtonDescriptionInfo.onClickAction.InvokeIfNotNull();
            onButtonClicked.InvokeIfNotNull();
        }
    }
}
