using ImpossibleOdds.Popups;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class TestPopupsUITK : TestPopups
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
    
    public override void ShowCustom()
    {
        CustomUITKPopup popup = new CustomUITKPopup(this.customUITKPopup);
        popup.onConfirmName += SayHello;
        
        Popup.ShowCustom(popup);
    }
}
