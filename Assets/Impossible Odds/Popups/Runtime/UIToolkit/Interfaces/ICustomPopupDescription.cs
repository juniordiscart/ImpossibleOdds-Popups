namespace ImpossibleOdds.Popups.UIToolkit
{ 
    /// <summary>
    /// Description for custom popups in the UI Toolkit popup display system.
    /// </summary>
    public interface ICustomPopupDescription : ImpossibleOdds.Popups.ICustomPopupDescription
    {
        /// <summary>
        /// Get the contents to be put in the popup window.
        /// </summary>
        /// <returns>The contents of the popup window.</returns>
        ICustomPopupContents GetPopupContents();
    }
}
