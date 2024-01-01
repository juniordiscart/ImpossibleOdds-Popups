using System;
using System.Collections;
using System.Collections.Generic;
using ImpossibleOdds;
using ImpossibleOdds.Popups;
using UnityEngine;

public class TestPopups : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Popup.ShowNotification(new NotificationPopup()
            {
                header = "Notification",
                contents = "This is a notification popup to notify the player of something. It's purpose is to inform and be clicked away.",
                hideButton = new PopupButton()
                {
                    text = "Ok",
                    onClickAction = () => Log.Info("Player has been notified.")
                }
            });
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Popup.ShowConfirmation(new ConfirmationPopup()
            {
                header = "Confirmation",
                contents = "This is a confirmation popup to present the player with the choice of confirming an action, or cancel it.",
                confirmButton = new PopupButton()
                {
                    text = "Confirm",
                    onClickAction = () => Log.Info("Player confirms the choice.")
                },
                cancelButton = new PopupButton()
                {
                    text = "Cancel",
                    onClickAction = () => Log.Info("The player requests to cancel the action.")
                }
            });
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Popup.ShowComplex(new ComplexPopup()
            {
                header = "Complex Options",
                contents = "This is a complex popup that presents the player with multiple options from which he can choose.",
                popupButtons = new[]
                {
                    new PopupButton()
                    {
                        text = "Save",
                        onClickAction = () => Log.Info("Just save.")
                    },
                    new PopupButton()
                    {
                        text = "Save & close",
                        onClickAction = () => Log.Info("Save and close the game.")
                    },
                    new PopupButton()
                    {
                        text = "Cancel",
                        onClickAction = () => Log.Info("Cancel.")
                    },
                }
            });
        }
    }
}
