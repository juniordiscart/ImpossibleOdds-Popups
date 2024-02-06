using System;
using ImpossibleOdds;
using ImpossibleOdds.Popups.UIToolkit;
using UnityEngine.UIElements;

public class CustomUITKPopup : ICustomPopupContents
{
    public event Action onClosePopup;
    public event Action<string> onConfirmName;

    private Button confirmButton;
    private TextField inputFieldName;

    public string Header => "Who are you?";

    public VisualElement ContentsRoot
    {
        get;
    }

    public CustomUITKPopup(VisualTreeAsset popupContentsAsset)
    {
        popupContentsAsset.ThrowIfNull(nameof(popupContentsAsset));
        ContentsRoot = popupContentsAsset.Instantiate();

        confirmButton = ContentsRoot.Q<Button>("ConfirmButton");
        confirmButton.clicked += OnConfirmName;
        confirmButton.SetEnabled(false);
        
        inputFieldName = ContentsRoot.Q<TextField>();
        inputFieldName.RegisterValueChangedCallback(OnNameChanged);
        
        ContentsRoot.Q<Button>("CancelButton").clicked += OnClose;
    }

    private void OnNameChanged(ChangeEvent<string> value)
    {
        confirmButton.SetEnabled(!value.newValue.IsNullOrEmpty());
    }

    private void OnConfirmName()
    {
        onConfirmName.InvokeIfNotNull(inputFieldName.value);
        onClosePopup.InvokeIfNotNull();
    }

    private void OnClose()
    {
        onClosePopup.InvokeIfNotNull();
    }
}
