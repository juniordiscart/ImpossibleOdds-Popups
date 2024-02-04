using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class TestPopupsUITK : TestPopups, ImpossibleOdds.Popups.UIToolkit.ICustomPopupDescription
{
    [SerializeField]
    private VisualTreeAsset customUITKPopup;

    private void Awake()
    {
        UIDocument document = GetComponent<UIDocument>();
        document.rootVisualElement.Q<Button>("ButtonNotification").clicked += ShowDefaultNotification;
        document.rootVisualElement.Q<Button>("ButtonConfirmation").clicked += ShowDefaultConfirmation;
        document.rootVisualElement.Q<Button>("ButtonComplex").clicked += ShowDefaultComplex;
        document.rootVisualElement.Q<Button>("ButtonCustom").clicked += ShowCustom;
    }

    ImpossibleOdds.Popups.UIToolkit.ICustomPopupContents ImpossibleOdds.Popups.UIToolkit.ICustomPopupDescription.GetPopupContents()
    {
        TestCustomUITKPopup customUITKPopup = new TestCustomUITKPopup(this.customUITKPopup);
        customUITKPopup.onConfirmName += SayHello;
        return customUITKPopup;
    }
}
