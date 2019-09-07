using Battleships.Models;
using System.Collections.Generic;
using System.Drawing;

namespace Battleships.Board
{
    /// <summary>
    /// The class responsible for creating game board.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// The game board tiles collection.
        /// </summary>
        public List<Tile> Tiles { get; set; }

        /// <summary>
        /// Constructor for creating new game board.
        /// </summary>
        public Board()
        {
            Tiles = new List<Tile>();

            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Tiles.Add(new Tile
                    {
                        Coordinates = new Point
                        {
                            X = i,
                            Y = j
                        }
                    });
                }
            }
        }
    }
}
