using System;
using ImpossibleOdds;
using ImpossibleOdds.Popups.Canvas;
using UnityEngine;
using UnityEngine.UI;

public class CustomCanvasPopup : MonoBehaviour, ICustomPopupContents
{
    public event Action onClosePopup;
    public event Action<string> onConfirmName; 
    
    [SerializeField]
    private InputField inputFieldName;

    [SerializeField]
    private Button buttonOk;
    [SerializeField]
    private Button buttonCancel;

    public string Header => "Who are you?";
    public bool DestroyAfterClose => true;
    public RectTransform ContentsRoot => transform as RectTransform;

    private void Awake()
    {
        inputFieldName.onValueChanged.AddListener(OnNameChanged);
        inputFieldName.onSubmit.AddListener(OnSubmitName);
        buttonOk.onClick.AddListener(OnConfirmName);
        buttonCancel.onClick.AddListener(OnClose);

        buttonOk.interactable = false;
    }

    private void OnNameChanged(string currentName)
    {
        buttonOk.interactable = !currentName.IsNullOrEmpty();
    }

    private void OnSubmitName(string currentName)
    {
        if (!currentName.IsNullOrEmpty())
        {
            OnConfirmName();
        }
    }

    private void OnConfirmName()
    {
        onConfirmName.InvokeIfNotNull(inputFieldName.text);
        onClosePopup.InvokeIfNotNull();
    }

    private void OnClose()
    {
        onClosePopup.InvokeIfNotNull();
    }
}
