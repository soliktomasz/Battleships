using System;
using System.Drawing;

namespace Battleships.Board
{
    public class Tile
    {
        public Point Coordinates { get; set; }
        public bool IsOccupied { get; set; }
        public Type OccupyingShipType { get; set; }
    }
}
