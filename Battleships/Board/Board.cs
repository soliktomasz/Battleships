using System.Collections.Generic;
using System.Drawing;

namespace Battleships.Board
{
    public class Board
    {
        public List<Tile> Tiles { get; set; }

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
