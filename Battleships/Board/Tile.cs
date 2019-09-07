using System;
using System.Drawing;

namespace Battleships.Board
{
    /// <summary>
    /// The model for board tile.
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// The coordinates of the tile.
        /// </summary>
        public Point Coordinates { get; set; }

        /// <summary>
        /// The indicator of whether tile is occupied. 
        /// <b>True</b> if tile is occupied by ship. Otherwise <b>false</b>.
        /// </summary>
        public bool IsOccupied { get; set; }

        /// <summary>
        /// The type of ship that is occupying tile.
        /// </summary>
        public Type OccupyingShipType { get; set; }
    }
}
