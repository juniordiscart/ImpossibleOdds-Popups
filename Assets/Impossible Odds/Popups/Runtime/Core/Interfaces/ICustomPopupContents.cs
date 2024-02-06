namespace ImpossibleOdds.Popups
{
    /// <summary>
    /// The base interface for custom popup contents.
    /// </summary>
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

