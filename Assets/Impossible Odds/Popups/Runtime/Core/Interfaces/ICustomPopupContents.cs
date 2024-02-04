namespace ImpossibleOdds.Popups
{
    public interface ICustomPopupContents : IPopupContents
    {
        /// <summary>
        /// The header for the popup to display.
        /// </summary>
        string Header
        {
            get;
        }
    }
}

