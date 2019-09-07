using System.Collections.Generic;
using System.Drawing;

namespace Battleships.Models
{
    /// <summary>
    /// The base model for each ship.
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// The size of the ship.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The amount of hits that the ship received.
        /// </summary>
        public int Hits { get; set; }

        /// <summary>
        /// The position of the ship on game board.
        /// </summary>
        public List<Point> Position { get; set; }
    }
}
