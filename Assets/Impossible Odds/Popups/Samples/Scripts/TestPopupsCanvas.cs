using ImpossibleOdds.Popups;
using UnityEngine;
using UnityEngine.UI;

public class TestPopupsCanvas : TestPopups
{
    [SerializeField]
    private Button buttonNotification;
    [SerializeField]
    private Button buttonConfirmation;
    [SerializeField]
    private Button buttonComplex;
    [SerializeField]
    private Button buttonCustom;

    [SerializeField]
    private CustomCanvasPopup customCanvasPopup;
    
    private void Awake()
    {
        buttonNotification.onClick.AddListener(ShowDefaultNotification);
        buttonConfirmation.onClick.AddListener(ShowDefaultConfirmation);
        buttonComplex.onClick.AddListener(ShowDefaultComplex);
        buttonCustom.onClick.AddListener(ShowCustom);
    }
    
    public override void ShowCustom()
    {
        CustomCanvasPopup popup = Instantiate(this.customCanvasPopup);
        popup.onConfirmName += SayHello;
        
        Popup.ShowCustom(popup);
    }
}
