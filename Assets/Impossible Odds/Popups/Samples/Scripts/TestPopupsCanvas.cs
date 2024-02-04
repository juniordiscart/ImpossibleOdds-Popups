using UnityEngine;
using UnityEngine.UI;

public class TestPopupsCanvas : TestPopups, ImpossibleOdds.Popups.Canvas.ICustomPopupDescription
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
    
    ImpossibleOdds.Popups.Canvas.ICustomPopupContents ImpossibleOdds.Popups.Canvas.ICustomPopupDescription.GetPopupContents()
    {
        CustomCanvasPopup customCanvasPopup = Instantiate(this.customCanvasPopup);
        customCanvasPopup.onConfirmName += SayHello;
        return customCanvasPopup;
    }
}
