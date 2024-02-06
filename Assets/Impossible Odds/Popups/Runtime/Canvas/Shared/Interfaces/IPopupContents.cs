namespace ImpossibleOdds.Popups.Canvas
{
    /// <summary>
    /// The base interface for popup contents to be displayed on the Canvas display system.
    /// </summary>
    public interface IPopupContents : ImpossibleOdds.Popups.IPopupContents
    {
        /// <summary>
        /// Should these popup contents be destroyed by the popup display system after it has been closed by the display system?
        /// </summary>
        bool DestroyAfterClose
        {
            get;
        }
    }
}

