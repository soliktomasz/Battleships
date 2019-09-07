namespace Battleships.Models
{
    /// <summary>
    /// The destroyer model.
    /// </summary>
    /// <remarks><seealso cref="Ship"/>.</remarks>
    public class Destroyer : Ship
    {
        /// <summary>
        /// Constructor for creating destroyer.
        /// </summary>
        public Destroyer()
        {
            Size = 4;
            Hits = 0;
        }
    }
}
