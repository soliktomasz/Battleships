namespace Battleships.Models
{
    /// <summary>
    /// The battleship model.
    /// </summary>
    /// <remarks><seealso cref="Ship"/>.</remarks>
    public class Battleship : Ship
    {
        /// <summary>
        /// Constructor for creating battleship.
        /// </summary>
        public Battleship()
        {
            Size = 5;
            Hits = 0;
        }
    }
}
