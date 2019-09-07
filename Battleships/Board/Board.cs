using System;
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
        /// <param name="size">The size of the board.</param>
        public Board(int size)
        {
            Tiles = new List<Tile>();

            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
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
