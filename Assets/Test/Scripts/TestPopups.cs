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
            Popup.ShowNotification(new NotificationPopupDescription()
            {
                header = "Notification",
                contents = "This is a notification popup to notify the player of something. It's purpose is to inform and be clicked away.",
                hideButtonDescription = new PopupButtonDescription()
                {
                    text = "Ok",
                    onClickAction = () => Log.Info("Player has been notified.")
                }
            });
        }
        else if (Input.GetKeyDown(KeyCode.C))
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
                    onClickAction = () => Log.Info("The player requests to cancel the action.")
                }
            });
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Popup.ShowComplex(new ComplexPopupDescription()
            {
                header = "Complex Options",
                contents = "This is a complex popup that presents the player with multiple options from which he can choose.",
                popupButtons = new[]
                {
                    new PopupButtonDescription()
                    {
                        text = "Save",
                        onClickAction = () => Log.Info("Just save.")
                    },
                    new PopupButtonDescription()
                    {
                        text = "Save & close",
                        onClickAction = () => Log.Info("Save and close the game.")
                    },
                    new PopupButtonDescription()
                    {
                        text = "Cancel",
                        onClickAction = () => Log.Info("Cancel.")
                    },
                }
            });
        }
    }
}
