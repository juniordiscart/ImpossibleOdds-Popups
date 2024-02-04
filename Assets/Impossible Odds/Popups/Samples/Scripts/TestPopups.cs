using ImpossibleOdds;
using ImpossibleOdds.Popups;
using UnityEngine;

public abstract class TestPopups : MonoBehaviour, ICustomPopupDescription
{
    public void ShowDefaultNotification()
    {
        Popup.ShowNotification(new NotificationPopupDescription()
        {
            header = "Notification",
            contents = "This is a notification popup to notify the player of something. Its purpose is just to inform and be clicked away.",
            hideButtonDescription = new PopupButtonDescription()
            {
                text = "Ok",
                onClickAction = () => Log.Info("Player has been notified.")
            }
        });
    }

    public void ShowDefaultConfirmation()
    {
        Popup.ShowConfirmation(new ConfirmationPopupDescription()
        {
            header = "Confirmation",
            contents = "This is a confirmation popup to present the player with the choice of confirming an action, or cancel it.",
            confirmButtonDescription = new PopupButtonDescription()
            {
                text = "Confirm",
                onClickAction = () => Log.Info("Player confirms the choice.")
            },
            cancelButtonDescription = new PopupButtonDescription()
            {
                text = "Cancel",
                onClickAction = () => Log.Info("Player requests to cancel the action.")
            }
        });
    }

    public void ShowDefaultComplex()
    {
        Popup.ShowComplex(new ComplexPopupDescription()
        {
            header = "Complex Options",
            contents = "This is a complex popup that presents the player with multiple options from which he can choose.",
            popupButtons = new[]
            {
                new PopupButtonDescription()
                {
                    text = "Got it",
                    onClickAction = () => Log.Info("Player understands it.")
                },
                new PopupButtonDescription()
                {
                    text = "More info",
                    onClickAction = () =>
                    {
                        Log.Info("Player requests more information about complex popups.");
                        Popup.ShowNotification(new NotificationPopupDescription()
                        {
                            header = "More info",
                            contents = "Complex popups simply allow you to easily add more than two options.",
                            hideButtonDescription = new PopupButtonDescription()
                            {
                                text = "Ok"
                            }
                        });
                    }
                },
                new PopupButtonDescription()
                {
                    text = "Cancel",
                    onClickAction = () => Log.Info("Player cancels the popup.")
                },
            }
        });   
    }
    
    public void ShowCustom()
    {
        Popup.ShowCustom(this);
    }
    
    public void SayHello(string name)
    {
        Popup.ShowNotification(new NotificationPopupDescription()
        {
            header = "Hello",
            contents = $"Hello {name}! Nice to meet you. We hope you enjoy working with this Popup system.\n\nIf not, let us know!",
            hideButtonDescription = new PopupButtonDescription()
            {
                text = "Ok"
            }
        });
    }
}
