using System.Collections.Generic;
using UnityEngine.UIElements;

namespace ImpossibleOdds.Popups.UIToolkit
{
    public class DefaultPopupWindow : PopupWindow
    {
        private DefaultPopupWindowConfiguration configuration;

        public DefaultPopupWindow(VisualElement visualElement, DefaultPopupWindowConfiguration configuration)
            : base(visualElement)
        {
            this.configuration = configuration;
        }

        public override string Header
        {
            get => PopupObject.Q<Label>(configuration.headerName).text;
            set => PopupObject.Q<Label>(configuration.headerName).text = value;
        }

        public string Contents
        {
            get => PopupObject.Q<Label>(configuration.contentsName).text;
            set => PopupObject.Q<Label>(configuration.contentsName).text = value;
        }

        public void SetButtons(IEnumerable<PopupButton> buttons)
        {
            buttons.ThrowIfNull(nameof(buttons));

            VisualElement buttonRoot = PopupObject.Q(configuration.buttonsRootName);
            
            foreach (PopupButton popupButton in buttons)
            {
                TemplateContainer buttonContainer = configuration.buttonTreeAsset.Instantiate();
                Button button = buttonContainer.Q<Button>();
                
                button.text = popupButton.text;

                if (popupButton.icon != null)
                {
                    button.Add(new Image()
                    {
                        image = popupButton.icon.texture
                    });
                }
                
                button.clicked += popupButton.onClickAction;
                button.clicked += CallOnHidePopup;
                buttonRoot.Add(buttonContainer);
            }
        }
    }
}
