using ImpossibleOdds;
using ImpossibleOdds.Popups;
using UnityEngine;

public abstract class TestPopups : MonoBehaviour
{
    public void ShowDefaultNotification()
    {
        Popup.ShowSimplePopup(new SimplePopupDescription()
        {
            Header = "Notification",
            Contents = "This is a notification popup to notify the player of something. Its purpose is just to inform and be clicked away.",
            Buttons = new[]
            {
                new PopupButtonDescription()
                {
                    text = "Ok",
                    onClickAction = () => Log.Info("Player has been notified.")
                }
            }
        });
    }

    public void ShowDefaultConfirmation()
    {
        Popup.ShowSimplePopup(new SimplePopupDescription()
        {
            Header = "Confirmation",
            Contents = "This is a confirmation popup to present the player with the choice of confirming an action, or cancel it.",
            Buttons = new[]
            {
                new PopupButtonDescription()
                {
                    text = "Confirm",
                    onClickAction = () => Log.Info("Player confirms the choice.")
                },
                new PopupButtonDescription()
                {
                    text = "Cancel",
                    onClickAction = () => Log.Info("Player requests to cancel the action.")
                }
            }
        });
    }

    public void ShowDefaultComplex()
    {
        Popup.ShowSimplePopup(new SimplePopupDescription()
        {
            Header = "Complex Options",
            Contents = "This is a complex popup that presents the player with multiple options from which he can choose.",
            Buttons = new[]
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
                        Popup.ShowSimplePopup(new SimplePopupDescription()
                        {
                            Header = "More info",
                            Contents = "Complex popups simply allow you to easily add more than two options.",
                            Buttons = new[]
                            {
                                new PopupButtonDescription()
                                {
                                    text = "Ok"
                                }
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

    public abstract void ShowCustom();

    public void SayHello(string name)
    {
        Popup.ShowSimplePopup(new SimplePopupDescription()
        {
            Header = "Hello",
            Contents = $"Hello {name}! Nice to meet you. We hope you enjoy working with this Popup system.\n\nIf not, let us know!",
            Buttons = new []
            {
                new PopupButtonDescription()
                {
                    text = "Ok"
                }                
            } 
        });
    }
}
